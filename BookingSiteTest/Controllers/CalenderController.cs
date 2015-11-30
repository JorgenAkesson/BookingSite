using System;
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
using WebMatrix.WebData;

namespace BookingSiteTest.Controllers
{
    public class CalenderController : Controller
    {
        private BookingContext db = new BookingContext();

        //
        // GET: /Calender/

        public ActionResult Index(int companyId)
        {
            var calenders = db.Calenders.Where(c => c.Company.Id == companyId);
            //var calenders = db.Calenders.Include(c => c.Company);
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

        public ActionResult ViewWeek(int id = 0)
        {
            Calender calender = db.Calenders.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }

            // Get the first day of current day.
            DayOfWeek firstDay = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDateInWeek = DateTime.Now.Date;
            while (firstDateInWeek.DayOfWeek != firstDay)
                firstDateInWeek = firstDateInWeek.AddDays(-1);
            var lastDateInWeek = firstDateInWeek.AddDays(7);

            //todo: remove
            firstDateInWeek =new DateTime(2015, 11, 9);
            lastDateInWeek = new DateTime(2015, 11, 16); 

            // Get activites for the current week
            var activities = db.Activities.Where(a => a.CalenderId == id && a.Date > firstDateInWeek && 
                a.Date < lastDateInWeek).ToList();
            
            ViewData["FirstDateInWeek"] = firstDateInWeek;
            ViewData["ActivitiesData"] = activities;

            return View(calender);
        }

        public ActionResult BookActivity(int activityId)
        {
            var activity = db.Activities.FirstOrDefault(a => a.Id == activityId);
            //var person = db.Persons.FirstOrDefault(a => a.Id == personId);
            return View(activity);
        }

        //
        // GET: /Calender/Create

        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "Id", "Name");
            //return ViewWeek();
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

        public ActionResult Book(int id)
        {
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
                UserId = WebSecurity.CurrentUserId,});

            db.SaveChanges();
            var activity = db.Activities.FirstOrDefault(a => a.Id == id);

            return RedirectToAction("ViewWeek", new {id = activity.CalenderId});
        }


        public JsonResult GetEvents(string start, string end, int calenderId)
        {
            var calender = db.Calenders.FirstOrDefault(a=> a.Id == calenderId);

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
                    description = activity.Bookings.Count() >= activity.MaxPerson ? true :false,
                };
                eventList.Add(ev);
            }
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }
    }
}