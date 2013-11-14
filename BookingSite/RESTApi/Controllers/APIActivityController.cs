using System.Collections.Generic;
using System.Web.Mvc;
using MvcApplication4.RESTApi.Models;
using WebsiteMvcApplication4.RESTApi.Models;

namespace MvcApplication4.RESTApi.Controllers
{
    public class APIActivityController : Controller
    {
        IActivityManager activtyManager;

        public APIActivityController()
        {
            this.activtyManager = new ActivityManager();
        }

        // /RESTApi/APIActivity
        // /RESTApi/APIActivity/2/10
        [HttpGet]
        public JsonResult APIActivityList(int? page, int? count)
        {
            var model = this.activtyManager.GetActivties(page, count);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
