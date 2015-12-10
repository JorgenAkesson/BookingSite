using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BookingSiteTest.Models;
using BookingSiteTest.Models.DAL;
using Newtonsoft.Json;

namespace BookingSiteTest.Controllers
{
    public class ActivityController : Controller
    {
        private BookingContext db = new BookingContext();

        //
        // GET: /Activity/

        public ActionResult Index(int calenderId = 0)
        {
            var activities = db.Activities.Include(a => a.Calender).Where(b => b.CalenderId == calenderId);
            ViewBag.CalenderId = calenderId;
            return View(activities.ToList());
        }

        // { 'name': $("#name").val(), 'nrOfPerson': $("#nrOfPerson").val(), 'date': date.format(), 'startTime': $("#startTime").val(), 'length': $("#length").val(), 'description': $("#description").val(), 'calenderId': <%: Model.Id%> }
        [HttpPost]
        public ActionResult CreateFromDialog(string jsonData)
        {
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);

            var activity = new Activity();
            activity.Name = data["name"];
            activity.MaxPerson = int.Parse(data["nrOfPerson"]);
            activity.Duration = int.Parse(data["length"]);
            activity.Description = data["description"];
            activity.CalenderId = int.Parse(data["calenderId"]);

            var timeSpann = TimeSpan.Parse(data["startTime"]);
            var date = DateTime.Parse(data["date"]);
            activity.Date = new DateTime(date.Year, date.Month, date.Day, timeSpann.Hours, timeSpann.Minutes, 0);
            activity.Time = timeSpann.Hours + ":" + timeSpann.Minutes;

            db.Activities.Add(activity);
            db.SaveChanges();

            return RedirectToAction("ViewWeek", "Calender", new { id = activity.CalenderId, activityDate = activity.Date });
        }

        //
        // GET: /Activity/Create

        public ActionResult Create(int calenderId = 0)
        {
            ViewBag.CalenderId = calenderId;
            return View();
        }

        //
        // POST: /Activity/Create

        [HttpPost]
        public ActionResult Create(Activity activity, int calenderId = 0)
        {
            if (ModelState.IsValid)
            {
                activity.CalenderId = calenderId;
                var timeSpann = TimeSpan.Parse(activity.Time);
                activity.Date = new DateTime(activity.Date.Year, activity.Date.Month, activity.Date.Day, timeSpann.Hours, timeSpann.Minutes, 0);
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index", new { calenderId = calenderId});
            }

            ViewBag.CalenderId = new SelectList(db.Calenders, "Id", "Name", activity.CalenderId);
            return View(activity);
        }

        //
        // GET: /Activity/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CalenderId = new SelectList(db.Calenders, "Id", "Name", activity.CalenderId);
            return View(activity);
        }

        //
        // POST: /Activity/Edit/5

        [HttpPost]
        public ActionResult Edit(Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { calenderId = activity.CalenderId });
            }
            ViewBag.CalenderId = new SelectList(db.Calenders, "Id", "Name", activity.CalenderId);
            return View(activity);
        }

        //
        // GET: /Activity/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        //
        // POST: /Activity/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            int calenderId = activity.CalenderId;
            db.Activities.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("Index", new { calenderId = calenderId });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}