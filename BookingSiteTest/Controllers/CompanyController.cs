using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingSiteTest.Models;
using BookingSiteTest.Models.DAL;
using BookingSiteTest.Views.Calender;

namespace BookingSiteTest.Controllers
{
    [HandleError]
    public class CompanyController : Controller
    {
        private const int UPLOAD_File_SIZE = 10000;

        private UsersContext db = new UsersContext();

        //
        // GET: /Company/

        public ActionResult Index()
        {
            var companies = db.Companies.Include(c => c.Address);
            return View(companies.ToList());
        }

        //
        // GET: /Company/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int id = 0)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        //
        // GET: /Company/Create

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Name");
            return View();
        }

        //
        // POST: /Company/Create

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.AddressId == null)
                {
                    db.Addresses.Add(company.Address);
                    db.SaveChanges();
                    company.AddressId = company.Address.Id;
                }
                company.Address.Id = (int)(company.AddressId);
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Name", company.AddressId);
            return View(company);
        }

        //
        // GET: /Company/Edit/5

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id = 0)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Name", company.AddressId);
            return View(company);
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                if (company.AddressId == null)
                {
                    db.Addresses.Add(company.Address);
                    db.SaveChanges();
                    company.AddressId = company.Address.Id;
                }
                company.Address.Id = (int)(company.AddressId);
                db.Entry(company).State = EntityState.Modified;
                db.Entry(company.Address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressId = new SelectList(db.Addresses, "Id", "Name", company.AddressId);
            return View(company);
        }

        //
        // GET: /Company/Delete/5

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id = 0)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        //
        // POST: /Company/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult FileUpload(HttpPostedFileBase uploadFile, int companyId)
        {
            if (uploadFile.ContentLength > 0 && uploadFile.ContentLength < UPLOAD_File_SIZE)
            {
                string filePath = Path.Combine(HttpContext.Server.MapPath("../App_Data/Uploads"), Guid.NewGuid().ToString() + "jpg");
                uploadFile.SaveAs(filePath);

                var company = db.Companies.First(a => a.Id == companyId);
                company.LogotypeImage = new Images()
                {
                    FilePath = filePath,
                };
                db.SaveChanges();
            }
            return RedirectToAction("Edit", new {id = companyId});
        }

        public FileResult GetImage(int imageId)
        {
            if (imageId == -1)
                return null;

            var im = db.Images.Find(imageId);

            Image image = Image.FromFile(im.FilePath);
            byte[] imageArray;

            using (var memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, ImageFormat.Jpeg);
                imageArray = memoryStream.ToArray();
            }

            return File(imageArray, "image/jpeg");
        }
    }
}