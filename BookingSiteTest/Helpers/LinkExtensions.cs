using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using BookingSiteTest.Models;
using BookingSiteTest.Models.DAL;
using WebMatrix.WebData;

namespace BookingSiteTest.Helpers
{
    public static class LinkExtensions
    {
        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName)
        {
            if (htmlHelper.ActionAuthorized(actionName, null))
            {
                return htmlHelper.ActionLink(linkText, actionName, null, null, null);
            }
            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues, int companyId)
        {
            if (htmlHelper.ActionAuthorized(actionName, null))
            {
                if (IsLoggedInUserAdmin(companyId))
                    return htmlHelper.ActionLink(linkText, actionName, null, new RouteValueDictionary(routeValues), null);
            }
            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, int companyId)
        {
            if (htmlHelper.ActionAuthorized(actionName, controllerName))
            {
                if (IsLoggedInUserAdmin(companyId))
                    return htmlHelper.ActionLink(linkText, actionName, controllerName, new RouteValueDictionary(routeValues), null);
            }
            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                         string controllerName, RouteValueDictionary routeValues,
                                                         IDictionary<string, object> htmlAttributes,
                                                         bool showActionLinkAsDisabled)
        {
            if (htmlHelper.ActionAuthorized(actionName, controllerName))
            {
                return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
            }
            return MvcHtmlString.Empty;
        }

        public static bool IsLoggedInUserAdmin(int companyId)
        {
            UsersContext uc = new UsersContext();
            UserProfile userProfile = uc.UserProfiles.Where(x => x.UserId == WebSecurity.CurrentUserId).FirstOrDefault();
            if (userProfile == null)
                return false;
            var isAdmin = System.Web.Security.Roles.GetRolesForUser().Contains("admin"); // Admin always see.

            UsersContext db = new UsersContext();
            // Check if logged in user is companyAdmin to this company 
            if (isAdmin || db.CompanyAdmin.Any(a => a.CompanyId == companyId && a.UserId == userProfile.UserId))
                return true;
            return false;
        }

    }

    public static class ActionExtensions
    {
        public static bool ActionAuthorized(this HtmlHelper htmlHelper, string actionName, string controllerName)
        {
            ControllerBase controllerBase = string.IsNullOrEmpty(controllerName) ? htmlHelper.ViewContext.Controller : htmlHelper.GetControllerByName(controllerName);
            ControllerContext controllerContext = new ControllerContext(htmlHelper.ViewContext.RequestContext, controllerBase);
            ControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor(controllerContext.Controller.GetType());
            ActionDescriptor actionDescriptor = controllerDescriptor.FindAction(controllerContext, actionName);

            if (actionDescriptor == null)
                return false;

            FilterInfo filters = new FilterInfo(FilterProviders.Providers.GetFilters(controllerContext, actionDescriptor));

            AuthorizationContext authorizationContext = new AuthorizationContext(controllerContext, actionDescriptor);
            foreach (IAuthorizationFilter authorizationFilter in filters.AuthorizationFilters)
            {
                authorizationFilter.OnAuthorization(authorizationContext);
                if (authorizationContext.Result != null)
                    return false;
            }
            return true;
        }

        private static ControllerBase GetControllerByName(this HtmlHelper htmlHelper, string controllerName)
        {
            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
            IController controller = factory.CreateController(htmlHelper.ViewContext.RequestContext, controllerName);
            if (controller == null)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, "The IControllerFactory '{0}' did not return a controller for the name '{1}'.", factory.GetType(), controllerName));
            }
            return (ControllerBase)controller;
        }
    }
}