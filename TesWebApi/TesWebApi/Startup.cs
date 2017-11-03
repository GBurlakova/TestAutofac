using Microsoft.Owin;
using Owin;
using Autofac;
using System.Web.Http;
using Autofac.Integration.WebApi;
using System.Reflection;
using TesWebApi.Services;

[assembly: OwinStartup(typeof(TesWebApi.Startup))]

namespace TesWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterType<Service>().As<IService>().InstancePerRequest();
            builder.RegisterType<ValidateBookTitleAttribute>().PropertiesAutowired();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;
        }
    }
}
