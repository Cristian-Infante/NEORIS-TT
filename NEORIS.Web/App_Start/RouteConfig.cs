using System.Web.Mvc;
using System.Web.Routing;

namespace NEORIS.Web.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authors", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
