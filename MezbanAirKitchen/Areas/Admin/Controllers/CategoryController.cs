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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(FormCollection fc)
        {

            return Json(new { });
        }
        public ActionResult Edit()
        {
            return View();
        }
    }
}