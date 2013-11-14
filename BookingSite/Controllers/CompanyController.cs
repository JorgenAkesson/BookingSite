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


namespace MvcApplication4.Controllers
{
    public class CompanyController : Controller
    {
        private BookingSiteEntities db = new BookingSiteEntities();

        //
        // GET: /Company/

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

            ViewBag.MovieType = items;

            return View();
        }

        public ActionResult CompanySelected(string MovieType)
        {
            ViewBag.messageString = MovieType;

            return RedirectToAction("Booking", "Activity", new { CompanyId = MovieType });

        }

        //
        // GET: /Company/Details/5

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
                company.AdministratorPersonId = int.Parse(Persons);
                db.Company.Add(company);
                db.SaveChanges();
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
                selectListItems.Add(new SelectListItem { Text = comp.FirstName + comp.LastName, Value = comp.Id.ToString() });
            }
            // Set selected person
            var person = selectListItems.Where(a => a.Value == company.AdministratorPersonId.ToString()).FirstOrDefault();
            person.Selected = true;
            ViewBag.Persons = selectListItems;

            return View(company);
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company, string Persons)
        {
            if (ModelState.IsValid)
            {
                company.AdministratorPersonId = int.Parse(Persons);
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        //
        // GET: /Company/Delete/5

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