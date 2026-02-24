using System.Web;
using System.Web.Http;
using NEORIS.Api.App_Start;
using NEORIS.Api.Infrastructure;

namespace NEORIS.Api
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutofacWebApiConfig.Register(GlobalConfiguration.Configuration);
            SwaggerConfig.Register();

            var connectionString = System.Configuration.ConfigurationManager
                .ConnectionStrings["NeorisLibraryDB"].ConnectionString;
            new DatabaseInitializer(connectionString).EnsureCreated();
        }
    }
}
