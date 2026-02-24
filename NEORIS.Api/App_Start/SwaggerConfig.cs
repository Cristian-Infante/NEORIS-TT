using System;
using System.IO;
using System.Web.Http;
using Swashbuckle.Application;
using System.Web.Hosting;

namespace NEORIS.Api.App_Start
{
    public static class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "NEORIS API");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi();
        }

        private static string GetXmlCommentsPath()
        {
            return HostingEnvironment.MapPath("~/bin/NEORIS.Api.xml");
        }
    }
}
