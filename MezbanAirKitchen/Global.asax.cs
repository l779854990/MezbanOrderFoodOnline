using Autofac;
using MezbanAirKitchen.Dependency;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using MezbanAdmin;

namespace MezbanAirKitchen
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.EnsureInitialized();

            var builder = new ContainerBuilder();
            builder.RegisterModule(new EfModule());
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());

            var config = GlobalConfiguration.Configuration;
            //Register your MVC controllers.
            var callingAssembly = Assembly.GetExecutingAssembly();
            builder.RegisterControllers(callingAssembly);

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            var resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);
        }
    }
}
