using System.Reflection;
using System.Web.Http;

using AspWebApplication.Repositories;

using Autofac;
using Autofac.Integration.WebApi;

using Microsoft.Extensions.Configuration;

using Serilog;

namespace AspWebApplication.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterServices(builder);
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();

            var configuration = new ConfigurationBuilder().AddJsonFile("application.json").Build();
            builder.Register<ILogger>((c, p) =>
            {
                return new LoggerConfiguration().ReadFrom.Configuration(configuration).Enrich.FromLogContext().CreateLogger();
            }).SingleInstance();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }

        private static void RegisterServices(ContainerBuilder builder)
        {


            builder.RegisterType<ProductRepository>().As<IProductRepository>().SingleInstance();
        }
    }
}
