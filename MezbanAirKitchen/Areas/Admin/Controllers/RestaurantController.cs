using MezbanAirKitchen.Controllers;
using MezbanService.Interfaces;
using System.Web.Mvc;

namespace MezbanAirKitchen.Areas.Admin.Controllers
{
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService, ILanguageService languageService, IAspNetUserService aspNetUserService) : base(languageService, aspNetUserService)
        {
            _restaurantService = restaurantService;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}