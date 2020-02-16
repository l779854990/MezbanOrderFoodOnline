using log4net;
using MezbanAirKitchen.Authentication;
using MezbanService.Interfaces;
using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Web.Mvc;

namespace MezbanAirKitchen.Controllers
{
    [CustomAuthorize]
    public class BaseController : Controller
    {
        public static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ILanguageService _languageService;
        private readonly IAspNetUserService _aspNetUserService;
        public BaseController (ILanguageService languageService, IAspNetUserService aspNetUserService)
        {
            _languageService = languageService;
            _aspNetUserService = aspNetUserService;
        }

        public string UserId()
        {
            var userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (!string.IsNullOrEmpty(userId)) return userId;

            return string.Empty;
        }

        public long GetCurrentLanguage()
        {
            //var lang = _languageService
            //    .Find(x => !x.IsDeleted && x.Status && x.Code == "vi");
            var l = ConfigurationManager.AppSettings["LanguageIdVi"];
            if (string.IsNullOrEmpty(l)) return long.Parse(l);
            return 1;
        }
    }
}