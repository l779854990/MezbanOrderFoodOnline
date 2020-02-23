using MezbanAirKitchen.Authentication;
using MezbanAirKitchen.Controllers;
using MezbanService.Interfaces;

namespace MezbanAirKitchen.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class AdminController : BaseController
    {
        public AdminController(ILanguageService languageService, IAspNetUserService aspNetUserService) : base(languageService, aspNetUserService)
        {
        }
    }
}