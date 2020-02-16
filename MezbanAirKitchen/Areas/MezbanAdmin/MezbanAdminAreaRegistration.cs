using System.Web.Mvc;

namespace MezbanAirKitchen
{
    public class MezbanAdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MezbanAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MezbanAdmin_default",
                "MezbanAdmin/{controller}/{action}/{id}",
                new { action = "Index",controller="Home", id = UrlParameter.Optional },
                new string [] { "MezbanAdmin.Controllers" }
            );
        }
    }
}