using System.Web.Mvc;

namespace MezbanAirKitchen
{
    public class MezbanOwnerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "MezbanOwner";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MezbanOwner_default",
                "MezbanOwner/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string [] { "MezbanOwner.Controllers" }
            );
        }
    }
}