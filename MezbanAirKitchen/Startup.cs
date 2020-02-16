using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MezbanAirKitchen.Startup))]
namespace MezbanAirKitchen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
