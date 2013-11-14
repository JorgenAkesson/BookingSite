using System.Web.Mvc;

namespace MvcApplication4.RESTApi
{
    public class ApiAreaRegistration : AreaRegistration
    {
        public override string AreaName { get { return "RESTApi"; } }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SingleComment",
                "RESTApi/Comments/Comment/{id}",
                new
                {
                    controller = "Comments",
                    action = "Comment",
                    id = UrlParameter.Optional
                }
            );
            context.MapRoute(
                "ListComments",
                "RESTApi/Comments/{page}/{count}",
                new
                {
                    controller = "Comments",
                    action = "CommentList",
                    page = UrlParameter.Optional,
                    count = UrlParameter.Optional
                }
            );
            context.MapRoute(
                "ListCommentsAll",
                "RESTApi/Comments",
                new
                {
                    controller = "Comments",
                    action = "CommentList",
                    page = UrlParameter.Optional,
                    count = UrlParameter.Optional
                }
            );
            context.MapRoute(
                "ListActivityAll",
                "RESTApi/APIActivity",
                new
                {
                    controller = "APIActivity",
                    action = "APIActivityList",
                    page = UrlParameter.Optional,
                    count = UrlParameter.Optional
                }
            );
            context.MapRoute(
                "Api_default",
                "RESTApi/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
