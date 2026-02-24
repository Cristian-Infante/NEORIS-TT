using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NEORIS.Web.App_Start;

namespace NEORIS.Web
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutofacMvcConfig.Register();
        }
    }
}
