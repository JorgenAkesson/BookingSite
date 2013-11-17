using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using MvcApplication1.Models;
using MvcApplication4.Models;
using WebMatrix.WebData;

namespace MvcApplication1.Controllers
{
    public class ActivityController : Controller
    {
        private BookingSiteEntities db = new BookingSiteEntities();

        public ActionResult MyActionOnController()
        {
            // TODO: You could return a PartialView here of course
            return Content("<div>Hello world</div>", "text/html");
        }
        
        //[Authorize(Roles = "Admin")]
        public ActionResult Test()
        {

            var pers = db.Person.First();
            var name = pers.Company.First().Name;

            ViewData["Message"] = "Viewbag data";

            using (var client = new WebClient());
            {
                string json = "";//" client.DownloadString("http://localhost:51012/RESTApi/APIActivity");

                // TODO: do something with this JSON data, like for example deserialize into a model
                var serializer = new JavaScriptSerializer();
                var model = serializer.Deserialize<List<Activity>>(json);
            }

            //pers = new Person("Jörgen", 45);
            return  View();
        }

        //
        // GET: /Activity/

        [Authorize(Roles = "Admin, CompanyAdmin")]
        public ActionResult Index()
        {
            var userId = WebSecurity.CurrentUserId;
            var personId = db.Person.Where(a => a.UserId == userId).FirstOrDefault().Id;
            var company = db.Company.FirstOrDefault(a => a.AdministratorPersonId == personId);
            if (company == null)
                return RedirectToAction("Index", "Company");

            return View(db.Activity.Where(a=>a.CompanyId == company.Id).ToList());
        }

        public ActionResult Booking(DateTime fromDate, DateTime toDate, int CompanyId = 0)
        {
            var id = WebSecurity.CurrentUserId;
            Person person = db.Person.Where(a => a.UserId == id).FirstOrDefault();
            var activities = db.Activity.Where(a => a.CompanyId == CompanyId && a.Date >= fromDate.Date && a.Date <= toDate.Date).ToList();
            var booking = new ActivitiesModel() { CopanyId = CompanyId, PersonId = person.Id, FirstName = person.FirstName, LastName = person.LastName, Activities = activities };
            ViewData["fromDate"] = fromDate;
            ViewData["toDate"] = toDate;

            return View( booking );
        }

        [HttpPost]
        public ActionResult Booking(ActivitiesModel activities)
        {

            return View();
        }


        public ActionResult Book(int activityId, DateTime fromDate, DateTime toDate)
        {
            var userId = WebSecurity.CurrentUserId;
            Person person = db.Person.Where(a => a.UserId == userId).FirstOrDefault();

            db.Booking.Add(new Booking() { ActivityId = activityId, PersonId = person.Id });
            db.SaveChanges();

            var CompanyId = db.Activity.First(a => a.Id == activityId).CompanyId;
            return RedirectToAction("Booking", new { CompanyId = CompanyId, fromDate = fromDate, toDate = toDate });
        }

        public ActionResult UnBook(int activityId, DateTime fromDate, DateTime toDate)
        {
            var userId = WebSecurity.CurrentUserId;
            Person person = db.Person.Where(a => a.UserId == userId).FirstOrDefault();

            var bookings = db.Booking.Where(a=> a.PersonId == person.Id && a.ActivityId == activityId);
            foreach (var booking in bookings)
            {
                db.Booking.Remove(booking);
            }
            db.SaveChanges();

            var companyId = db.Activity.First(a => a.Id == activityId).CompanyId;
            return RedirectToAction("Booking", new { CompanyId = companyId, fromDate = fromDate, toDate = toDate });
        }

        //
        // GET: /Activity/Details/5

        [Authorize(Roles = "Admin, CompanyAdmin")]
        public ActionResult Details(int id = 0, int number = 0)
        {
            Activity activity = db.Activity.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        //
        // GET: /Activity/Create

        [Authorize(Roles = "Admin, CompanyAdmin")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Activity/Create

        [Authorize(Roles = "Admin, CompanyAdmin")]
        [HttpPost]
        public ActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                var id = WebSecurity.CurrentUserId;
                var companyId = db.Company.Where(a=> a.Person.UserId == id).FirstOrDefault().Id;
                activity.CompanyId = companyId;
                db.Activity.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activity);
        }

        //
        // GET: /Activity/Edit/5

        [Authorize(Roles = "Admin, CompanyAdmin")]
        public ActionResult Edit(int id = 0)
        {
            Activity activity = db.Activity.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        //
        // POST: /Activity/Edit/5

        [Authorize(Roles = "Admin, CompanyAdmin")]
        [HttpPost]
        public ActionResult Edit(Activity activity, DateTime datepicker)
        {
            if (ModelState.IsValid)
            {
                activity.Date = datepicker;
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activity);
        }

        //
        // GET: /Activity/Delete/5

        [Authorize(Roles = "Admin, CompanyAdmin")]
        public ActionResult Delete(int id = 0)
        {
            Activity activity = db.Activity.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        //
        // POST: /Activity/Delete/5

        [Authorize(Roles = "Admin, CompanyAdmin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activity.Find(id);
            db.Activity.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [Authorize(Roles = "Admin, CompanyAdmin")]
        public ActionResult Print(int activityId = 0)
        {
            Activity activity = db.Activity.Find(activityId);
            if (activity == null)
            {
                return HttpNotFound();
            }

            ActivityModel act = new ActivityModel() {Activity = activity};
            return View(act);
        }
    }
}