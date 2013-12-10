using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Models;
using MvcApplication4.Extensions;
using WebMatrix.WebData;
using System.Web.Security;


namespace MvcApplication4.Controllers
{
    public class CompanyController : BaseController
    {
        private const string ImageFolder = "~/Images/Uploads";
        private BookingSiteEntities db = new BookingSiteEntities();

        //
        // GET: /Company/

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Company.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Image(int id = 0)
        {
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Image(HttpPostedFileBase file, Company company)
        {
            if (file.ContentLength > 0)
            {
                // Remove old images first
                DirectoryInfo directory = new DirectoryInfo(Server.MapPath(@ImageFolder));
                var filesInfos = directory.GetFiles().ToList().Where(a => a.Name.Contains("_" + company.Id.ToString()));
                foreach (var filesInfo in filesInfos)
                {
                    System.IO.File.Delete(filesInfo.FullName);
                }

                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var path = Path.Combine(Server.MapPath(ImageFolder), fileName + "_" + company.Id + Path.GetExtension(file.FileName));
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        public ActionResult ViewCompaniesAndSelect(int CityId = 1)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            DirectoryInfo directory = new DirectoryInfo(Server.MapPath(@ImageFolder));
            List<ViewCompaniesDataModel> ViewCompaniesData = new List<ViewCompaniesDataModel>();

            foreach (var comp in db.Company)
            {
                // Get all unique sities
                foreach(var activity in  comp.Activity)
                {
                    if(items.Count(a=> a.Value == activity.CityId.ToString()) == 0)
                    {
                        items.Add(new SelectListItem{Text = activity.City.Name, Value = activity.Id.ToString()});
                    }
                }

                var files = directory.GetFiles().ToList();
                var fileInfo = files.Where(a => a.Name.Contains("_" + comp.Id.ToString())).FirstOrDefault();

                if (fileInfo != null)
                {
                    var hasCity = comp.Activity.Where(a => a.CityId == CityId).Count() > 0;
                    if (hasCity)
                    {
                        string filPath = ImageFolder + "/" + fileInfo.Name;
                        ViewCompaniesData.Add(new ViewCompaniesDataModel() { CompanyId = comp.Id, Name = comp.Name, ImageUrl = filPath });
                    }
                }
            }
            
            ViewData["ViewCompaniesData"] = ViewCompaniesData;
            ViewData["ViewBagCities"] = items;

            return View();
        }

        public class ViewCompaniesDataModel
        {
            public string  ImageUrl { get; set; }
            public int CompanyId { get; set; }
            public string Name { get; set; }
        }

        public ActionResult CompanySelected(string CompanyId)
        {
            ViewBag.messageString = CompanyId;
            DateTime firstDayOfWeek = DateTime.Now.GetFirstDayOfWeek();
            DateTime lastDayOfWeek = DateTime.Now.GetLastDayOfWeek();
            return RedirectToAction("Booking", "Activity", new { CompanyId = CompanyId, fromDate = firstDayOfWeek, toDate = lastDayOfWeek });

        }

        //
        // GET: /Company/Details/5

        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id = 0)
        {
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        //
        // GET: /Company/Create

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var comp in db.Person)
            {
                items.Add(new SelectListItem { Text = comp.FirstName + comp.LastName, Value = comp.Id.ToString() });
            }
            ViewBag.Persons = items;
            return View();
        }

        //
        // POST: /Company/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company, string Persons)
        {
            if (ModelState.IsValid)
            {
                int? personId = company.AdministratorPersonId = int.Parse(Persons);
                db.Company.Add(company);
                db.SaveChanges();

                HandleUserRole(null, personId);

                return RedirectToAction("Index");
            }
            return View(company);
        }

        //
        // GET: /Company/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var comp in db.Person)
            {
                selectListItems.Add(new SelectListItem { Text = comp.FirstName + " " + comp.LastName, Value = comp.Id.ToString() });
            }
            // Set selected person
            var person = selectListItems.Where(a => a.Value == company.AdministratorPersonId.ToString()).FirstOrDefault();
            person.Selected = true;
            ViewData["Persons"] = selectListItems;
            ViewData["OldAdminPersonId"] = company.AdministratorPersonId;

            return View(company);
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company, int OldAdminPersonId, string Persons)
        {
            if (ModelState.IsValid)
            {
                int? personId = company.AdministratorPersonId = (int.Parse(Persons));
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();

                HandleUserRole(OldAdminPersonId, personId);

                return RedirectToAction("Index");
            }
            return View(company);
        }

        private void HandleUserRole(int? OldAdminPersonId, int? personId)
        {
            int userId = db.Person.First(a => a.Id == personId).UserId;
            int oldUserId = OldAdminPersonId != null ? db.Person.First(a => a.Id == OldAdminPersonId).UserId : -1;

            // Handle Roles and asp.net membership
            if (!Roles.RoleExists("CompanyAdmin"))
                Roles.CreateRole("CompanyAdmin");

            string userName = "";
            string oldUserName = "";
            using (var ctx = new UsersContext())
            {
                userName = ctx.UserProfiles.First(a => a.UserId == userId).UserName;
                oldUserName = oldUserId != -1 ? ctx.UserProfiles.First(a => a.UserId == oldUserId).UserName : "";
            }

            // Remove old user admin
            if (Roles.GetUsersInRole("CompanyAdmin").Contains(oldUserName))
            {
                Roles.RemoveUserFromRole(oldUserName, "CompanyAdmin");
            }

            // Add new user admin
            if (!Roles.GetUsersInRole("CompanyAdmin").Contains(userName))
            {
                Roles.AddUserToRole(userName, "CompanyAdmin");
            }
        }

        //
        // GET: /Company/Delete/5

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id = 0)
        {
            Company company = db.Company.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        //
        // POST: /Company/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Company.Find(id);
            db.Company.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}