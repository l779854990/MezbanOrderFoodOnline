using Autofac;
using MezbanAirKitchen.Dependency;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using MezbanAirKitchen.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MezbanData.DbContext;
using System;

namespace MezbanAirKitchen
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
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
           // CreateRolesAndUsers();
        }
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Admin" };
                roleManager.Create(role);
                var person = new Person
                {
                    PersonId = Guid.NewGuid(),
                    FisrtName = "Minh",
                    LastName = "Hieu"
                };
                using (var db = new MezbanAirKitchenEntities())
                {
                    db.Persons.Add(person);
                    db.SaveChanges();
                };
                var user = new ApplicationUser
                {
                    UserName = "admin_mezban",
                    Email = "minhhieuit28@gmail.com",
                    PersonId = person.PersonId
                };

                string userPWD = "Admin@321";

                var chkUser = userManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");
                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Owner"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Owner" };
                roleManager.Create(role);
            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Employee" };
                roleManager.Create(role);
            }
        }
    }
}
