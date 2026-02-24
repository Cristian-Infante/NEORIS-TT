using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.EntityFrameworkCore;
using NEORIS.Application.Interfaces;
using NEORIS.Application.Mappers;
using NEORIS.Application.Services;
using NEORIS.Application.Validators;
using NEORIS.Domain.Interfaces;
using NEORIS.Infrastructure.Data;
using NEORIS.Infrastructure.Repositories;
using NEORIS.Api.Infrastructure;

namespace NEORIS.Api.App_Start
{
    public static class AutofacWebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register(c =>
            {
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlServer(System.Configuration.ConfigurationManager
                        .ConnectionStrings["NeorisLibraryDB"].ConnectionString)
                    .Options;
                return new AppDbContext(options);
            }).AsSelf().InstancePerRequest();

            builder.RegisterType<BookRepository>().As<IBookRepository>().InstancePerRequest();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>().InstancePerRequest();

            builder.RegisterType<AppSettingsProvider>().As<IAppSettings>().SingleInstance();

            builder.RegisterType<BookValidator>().As<IBookValidator>().InstancePerRequest();
            builder.RegisterType<AuthorValidator>().As<IAuthorValidator>().InstancePerRequest();
            builder.RegisterType<BookMapper>().As<IBookMapper>().SingleInstance();
            builder.RegisterType<AuthorMapper>().As<IAuthorMapper>().SingleInstance();

            builder.RegisterType<BookService>().As<IBookService>().InstancePerRequest();
            builder.RegisterType<AuthorService>().As<IAuthorService>().InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
