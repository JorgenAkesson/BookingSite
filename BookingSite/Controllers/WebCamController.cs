using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    public class WebCamController : Controller
    {
        //
        // GET: /WebCam/
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

    }
}
