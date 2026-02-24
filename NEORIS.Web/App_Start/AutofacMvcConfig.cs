using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using NEORIS.Web.Services;

namespace NEORIS.Web.App_Start
{
    public static class AutofacMvcConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var apiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];

            builder.Register(c =>
            {
                var client = new HttpClient { BaseAddress = new Uri(apiBaseUrl) };
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                return client;
            }).AsSelf().InstancePerRequest();

            builder.RegisterType<ApiResponseParser>().As<IApiResponseParser>().SingleInstance();
            builder.RegisterType<BookApiClient>().As<IBookApiClient>().InstancePerRequest();
            builder.RegisterType<AuthorApiClient>().As<IAuthorApiClient>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
