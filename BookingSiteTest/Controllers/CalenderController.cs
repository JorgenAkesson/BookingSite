using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BookingSiteTest.Helpers;
using BookingSiteTest.Models;
using BookingSiteTest.Models.DAL;
using BookingSiteTest.Models.ViewModels;
using Newtonsoft.Json;
using WebMatrix.WebData;

namespace BookingSiteTest.Controllers
{
    public class CalenderController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Calender/
        public ActionResult Index(int companyId = 0)
        {
            var calenders = db.Calenders.Where(c => c.Company.Id == companyId);
            var company = db.Companies.First(c => c.Id == companyId);
            //var calenders = db.Calenders.Include(c => c.Company);
            ViewBag.CompanyId = companyId;
            ViewBag.CompanyName = company.Name;
            return View(calenders.ToList());
        }

        //
        // GET: /Calender/Details/5
        [Authorize(Roles = "companyAdmin, admin")]
        public ActionResult Details(int id = 0)
        {
            Calender calender = db.Calenders.Find(id);
            if (calender == null)
            {
                return RedirectToAction("IncorrectData", "Error");
            }
            bool IsAdmin = LinkExtensions.IsLoggedInUserAdmin(calender.CompanyID);
            if (!IsAdmin)
            {
                return RedirectToAction("NotAuthorized", "Error");
            }
            return View(calender);
        }

        //
        // GET: /Calender/Details/5

        // /Calender/ViewWeek?id=2&activityDate=2015-12-20 11:00:00	
        //public ActionResult ViewWeek(int id = 0, DateTime? activityDate = null)
        public ActionResult ViewWeek(int id = 0, string activityDate = null)
        {
            Calender calender = db.Calenders.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }
            if (activityDate == null)
            {
                activityDate = DateTime.Now.ToShortDateString();
            }

            ViewData["ActivityDate"] = activityDate;
            ViewBag.IsUserAdmin = LinkExtensions.IsLoggedInUserAdmin(calender.CompanyID);
            return View(calender);
        }

        public ActionResult BookActivity(int activityId = 0)
        {
            var activity = db.Activities.FirstOrDefault(a => a.Id == activityId);
            var activityBooking = new ActivityBooking()
            {
                Activity = activity,
                Customer = new Customer(),
                Note = "",
            };
            return View(activityBooking);
        }

        [HttpPost]
        public ActionResult BookActivity(ActivityBooking activityBooking)
        {
            var a = activityBooking;

            db.Bookings.Add(new Booking()
            {
                ActivityId = activityBooking.Activity.Id,
                Note = activityBooking.Note,
                Customer = activityBooking.Customer,
            });
            db.SaveChanges();

            return RedirectToAction("ViewWeek", "Calender", new { id = activityBooking.Activity.CalenderId, activityDate = activityBooking.Activity.Date.ToShortDateString() });
        }

        //
        // GET: /Calender/Create
        [Authorize(Roles = "companyAdmin, admin")]
        public ActionResult Create(int companyId)
        {
            bool IsAdmin = LinkExtensions.IsLoggedInUserAdmin(companyId);
            if (!IsAdmin)
            {
                return RedirectToAction("NotAuthorized", "Error");
            }
            ViewBag.CompanyID = companyId;
            ViewBag.CompanyId = companyId;
            return View();
        }

        //
        // POST: /Calender/Create

        [HttpPost]
        [Authorize(Roles = "companyAdmin, admin")]
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
        [Authorize(Roles = "companyAdmin, admin")]
        public ActionResult Edit(int id = 0)
        {
            Calender calender = db.Calenders.Find(id);
            if (calender == null)
            {
                return RedirectToAction("IncorrectData", "Error");
            }
            bool IsAdmin = LinkExtensions.IsLoggedInUserAdmin(calender.CompanyID);
            if (!IsAdmin)
            {
                return RedirectToAction("NotAuthorized", "Error");
            }
            ViewBag.CompanyID = calender.CompanyID;
            return View(calender);
        }

        //
        // POST: /Calender/Edit/5

        [HttpPost]
        [Authorize(Roles = "companyAdmin, admin")]
        public ActionResult Edit(Calender calender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calender).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", new { companyId = calender.CompanyID });
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "Id", "Name", calender.CompanyID);
            return View(calender);
        }

        //
        // GET: /Calender/Delete/5
        [Authorize(Roles = "companyAdmin, admin")]
        public ActionResult Delete(int id = 0)
        {
            Calender calender = db.Calenders.Find(id);
            if (calender == null)
            {
                return RedirectToAction("IncorrectData", "Error");
            }
            bool IsAdmin = LinkExtensions.IsLoggedInUserAdmin(calender.CompanyID);
            if (!IsAdmin)
            {
                return RedirectToAction("NotAuthorized", "Error");
            }

            return View(calender);
        }

        //
        // POST: /Calender/Delete/5
        [Authorize(Roles = "companyAdmin, admin")]
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

        //public ActionResult Book(string id, string note) // ActivityId
        public void Book(string id, string note) // ActivityId
        {
            int idi = int.Parse(id);

            //if (!WebSecurity.Initialized)
            //{
            //    WebSecurity.InitializeDatabaseConnection(
            //        "DefaultConnection", "User", "UserId", "UserName",
            //        autoCreateTables: false);
            //}

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
        }


        public JsonResult GetEvents(string start, string end, int calenderId)
        {
            var calender = db.Calenders.FirstOrDefault(a => a.Id == calenderId);

            var userId = WebSecurity.CurrentUserId;


            List<Events> eventList = new List<Events>();
            foreach (var activity in calender.Activities)
            {
                var bookedByMe = activity.Bookings.Any(a => a.UserId == userId);
                var fullyBooked = activity.Bookings.Count() >= activity.MaxPerson;
                string bGColor;
                if (bookedByMe)
                    bGColor = "#7FAAFF"; // Ljusblå
                else if (fullyBooked)
                    bGColor = "#FCBABB"; // Ljusröd
                else
                    bGColor = "#ABE99C"; // Grön

                TimeSpan timeSpan = TimeSpan.Parse(activity.Time);
                var startDate = activity.Date.AddHours(timeSpan.Hours).AddMinutes(timeSpan.Minutes);
                var ev = new Events()
                {
                    id = activity.Id.ToString(),
                    title = activity.Name,
                    start = startDate.ToString(),
                    end = startDate.AddMinutes(activity.Duration).ToString(),
                    allDay = false,
                    color = bGColor,
                    textColor = "#444444",
                    fullyBooked = fullyBooked,
                    bookedByMe = bookedByMe,
                };
                eventList.Add(ev);
            }
            var rows = eventList.ToArray();
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "companyAdmin, admin")]
        public ActionResult Bookings(int calenderid, DateTime fromdate, DateTime todate)
        {
            var udb = new UsersContext();
            var calender = db.Calenders.FirstOrDefault(a => a.Id == calenderid);
            if (calender == null)
            {
                return RedirectToAction("IncorrectData", "Error");
            }
            bool IsAdmin = LinkExtensions.IsLoggedInUserAdmin(calender.CompanyID);
            if (!IsAdmin)
            {
                return RedirectToAction("NotAuthorized", "Error");
            }

            var activities = calender.Activities.Where(a => a.Date.Date >= fromdate.Date && a.Date.Date <= todate.Date).ToList();
            foreach (var activity in activities)
            {
                foreach (var booking in activity.Bookings)
                {
                    if (booking.UserId != null)
                        booking.User = udb.UserProfiles.First(a => a.UserId == booking.UserId);
                }
            }
            ViewBag.CompanyId = calender.CompanyID;
            ViewBag.CalenderId = calenderid;
            ViewBag.FromDate = fromdate.Date.ToShortDateString();
            return View(activities);
        }
    }
}