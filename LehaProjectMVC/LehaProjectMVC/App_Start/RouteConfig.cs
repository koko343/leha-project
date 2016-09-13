using System.Web.Mvc;
using System.Web.Routing;

namespace LehaProjectMVC.App_Start
{
    public class RouteConfig
    {
        public static void Configure(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Admin",
                url: "{controller}/{action}",
                defaults: new { controller = "Admin", action = "AdminPanel" }
            );
        }
    }
}