using MezbanService.Interfaces;
using System.Web.Mvc;

namespace MezbanAirKitchen.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public HomeController(ILanguageService languageService, IAspNetUserService aspNetUserService) : base(languageService, aspNetUserService)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}