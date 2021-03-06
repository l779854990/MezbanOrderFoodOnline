﻿using System.Web.Mvc;
using MezbanService.Interfaces;

namespace MezbanAirKitchen.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(ILanguageService languageService, IAspNetUserService aspNetUserService) : base(languageService, aspNetUserService)
        {

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}