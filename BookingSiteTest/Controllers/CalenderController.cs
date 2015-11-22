using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingSiteTest.Models;
using BookingSiteTest.Models.DAL;

namespace BookingSiteTest.Controllers
{
    public class CalenderController : Controller
    {
        private BookingContext db = new BookingContext();

        //
        // GET: /Calender/

        public ActionResult Index()
        {
            var calenders = db.Calenders.Include(c => c.Company);
            return View(calenders.ToList());
        }

        //
        // GET: /Calender/Details/5

        public ActionResult Details(int id = 0)
        {
            Calender calender = db.Calenders.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }
            return View(calender);
        }

        //
        // GET: /Calender/Create

        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "Id", "Name");
            return View();
        }

        //
        // POST: /Calender/Create

        [HttpPost]
        public ActionResult Create(Calender calender)
        {
            if (ModelState.IsValid)
            {
                db.Calenders.Add(calender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "Id", "Name", calender.CompanyID);
            return View(calender);
        }

        //
        // GET: /Calender/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Calender calender = db.Calenders.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "Id", "Name", calender.CompanyID);
            return View(calender);
        }

        //
        // POST: /Calender/Edit/5

        [HttpPost]
        public ActionResult Edit(Calender calender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "Id", "Name", calender.CompanyID);
            return View(calender);
        }

        //
        // GET: /Calender/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Calender calender = db.Calenders.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }
            return View(calender);
        }

        //
        // POST: /Calender/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Calender calender = db.Calenders.Find(id);
            db.Calenders.Remove(calender);
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