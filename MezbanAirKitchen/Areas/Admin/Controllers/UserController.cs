﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MezbanAirKitchen.Controllers;
using MezbanService.Interfaces;

namespace MezbanAirKitchen.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        public UserController(ILanguageService languageService, IAspNetUserService aspNetUserService) : base(languageService, aspNetUserService)
        {
        }
        // GET: Admin/Promotion
        public ActionResult Index()
        {
            return View();
        }
    }
}