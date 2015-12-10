﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BookingSiteTest.Models;
using BookingSiteTest.Models.DAL;
using Newtonsoft.Json;
using WebMatrix.WebData;

namespace BookingSiteTest.Controllers
{
    public class CalenderController : Controller
    {
        private BookingContext db = new BookingContext();

        //
        // GET: /Calender/

        public ActionResult Index(int companyId = 0)
        {
            var calenders = db.Calenders.Where(c => c.Company.Id == companyId);
            //var calenders = db.Calenders.Include(c => c.Company);
            ViewBag.CompanyId = companyId;
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
        // GET: /Calender/Details/5

        public ActionResult ViewWeek(int id = 0, DateTime? activityDate = null)
        {
            Calender calender = db.Calenders.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }


            if (activityDate == null)
            {
                activityDate = DateTime.Now;
            }

            ViewData["ActivityDate"] = activityDate;
            return View(calender);
        }

        public ActionResult BookActivity(int activityId)
        {
            var activity = db.Activities.FirstOrDefault(a => a.Id == activityId);
            return View(activity);
        }

        //
        // GET: /Calender/Create

        public ActionResult Create(string companyId)
        {
            ViewBag.CompanyID = companyId;
            //return ViewWeek();
            ViewBag.CompanyId = companyId;
            return View();
        }

        //
        // POST: /Calender/Create

        [HttpPost]
        public ActionResult Create(Calender calender, string companyId)
        {
            if (ModelState.IsValid)
            {
                db.Calenders.Add(calender);
                db.SaveChanges();
                return RedirectToAction("Index", new { companyId = companyId });
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
            ViewBag.CompanyID = calender.CompanyID;
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
                
                return RedirectToAction("Index", new { companyId = calender.CompanyID});
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
            var companyId = calender.CompanyID;
            db.Calenders.Remove(calender);
            db.SaveChanges();

            return RedirectToAction("Index", new { companyId = companyId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        // { 'bookNote': $("#bookNote").val(), 'activityId': event.id }
        public ActionResult Book2(string jsonData) // ActivityId
        {
            int id = 0;
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
            id = int.Parse(data["activityId"]);
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection(
                    "DefaultConnection", "UserProfile", "UserId", "UserName",
                    autoCreateTables: false);
            }

            UsersContext uc = new UsersContext();
            UserProfile userProfile = uc.UserProfiles.Where(x => x.UserId == WebSecurity.CurrentUserId).FirstOrDefault();

            //var fname = userProfile.FirstName;
            //var laname = userProfile.LastName;

            db.Bookings.Add(new Booking()
            {
                ActivityId = id,
                UserId = WebSecurity.CurrentUserId,
            });

            db.SaveChanges();
            var activity = db.Activities.FirstOrDefault(a => a.Id == id);

            return RedirectToAction("ViewWeek", new { id = activity.CalenderId });
        }

        //public ActionResult Book(string id, string note) // ActivityId
        public void Book(string id, string note) // ActivityId
        {
            int idi = int.Parse(id);
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection(
                    "DefaultConnection", "UserProfile", "UserId", "UserName",
                    autoCreateTables: false);
            }

            UsersContext uc = new UsersContext();
            UserProfile userProfile = uc.UserProfiles.Where(x => x.UserId == WebSecurity.CurrentUserId).FirstOrDefault();

            //var fname = userProfile.FirstName;
            //var laname = userProfile.LastName;

            db.Bookings.Add(new Booking()
            {
                ActivityId = idi,
                UserId = WebSecurity.CurrentUserId,
                Note = note,
            });
            db.SaveChanges();

            var activity = db.Activities.FirstOrDefault(a => a.Id == idi);

            //return RedirectToAction("ViewWeek", new { id = activity.CalenderId, activityDate = activity.Date });
        }


        public JsonResult GetEvents(string start, string end, int calenderId)
        {
            var calender = db.Calenders.FirstOrDefault(a => a.Id == calenderId);

            List<Events> eventList = new List<Events>();
            foreach (var activity in calender.Activities)
            {
                var ev = new Events()
                {
                    id = activity.Id.ToString(),
                    title = activity.Name,
                    start = activity.Date.ToString(),
                    end = activity.Date.AddMinutes(activity.Duration).ToString(),
                    allDay = false,
                    color = activity.Bookings.Count() >= activity.MaxPerson ? "#FCBABB" : "#ABE99C",
                    textColor = "#444444",
                    description = activity.Bookings.Count() >= activity.MaxPerson ? true : false,
                };
                eventList.Add(ev);
            }
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
    }
}