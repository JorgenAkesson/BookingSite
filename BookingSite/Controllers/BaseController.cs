using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var action = filterContext.Result as ViewResult;
            if (action != null)
            {
                if (Request.Browser.IsMobileDevice)
                    action.MasterName = "Mobile";
                else
                    action.MasterName = "Site";
            }

            base.OnActionExecuted(filterContext);
        }
    }
}