using MezbanAirKitchen.Controllers;
using MezbanService.Interfaces;
using System.Web.Mvc;

namespace MezbanAirKitchen.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        public CategoryController(ILanguageService languageService, IAspNetUserService aspNetUserService) : base(languageService, aspNetUserService)
        {
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}