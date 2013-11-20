using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Models;
using MvcApplication4.Extensions;
using WebMatrix.WebData;
using System.Web.Security;


namespace MvcApplication4.Controllers
{
    public class CompanyController : Controller
    {
        private BookingSiteEntities db = new BookingSiteEntities();

        //
        // GET: /Company/

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Company.ToList());
        }


        public ActionResult ViewCompaniesAndSelect()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var comp in db.Company)
            {
                items.Add(new SelectListItem { Text = comp.Name, Value = comp.Id.ToString() });
            }

            List<ViewCompaniesDataModel> ViewCompaniesData = new List<ViewCompaniesDataModel>();
            ViewCompaniesData.Add(new ViewCompaniesDataModel() { CompanyId = 6, Name = "Friskis", ImageUrl = "~/Images/friskis.jpg" });
            ViewCompaniesData.Add(new ViewCompaniesDataModel() { CompanyId = 7, Name = "Golden Wellness", ImageUrl = "~/Images/goldenwellness.png" });
            
            ViewData["CompanyList"] = items;
            ViewData["ViewCompaniesData"] = ViewCompaniesData;

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