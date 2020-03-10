using System;
using MezbanAirKitchen.Controllers;
using MezbanService.Interfaces;
using System.Web.Mvc;
using System.Web.Services.Description;
using MezbanCommon.Heplers;
using MezbanData.DbContext;
using MezbanModel.Category;
using Microsoft.Owin.Security.Provider;
using System.Linq;
using MezbanModel;

namespace MezbanAirKitchen.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ILanguageService _languageService;
        public CategoryController(ILanguageService languageService, IAspNetUserService aspNetUserService, ICategoryService categoryService) : base(languageService, aspNetUserService)
        {
            _categoryService = categoryService;
            _languageService = languageService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryCommandModel model, FormCollection fc)
        {
            var isOk = true;
            var names = fc.AllKeys
                .Where(x => x.StartsWith("fc[Name_"))
                .ToDictionary(k => k.Replace("fc[", "").Replace("]", ""), k => fc[k]);
            var discripitons = fc.AllKeys
                .Where(x => x.StartsWith("fc[Discription_"))
                .ToDictionary(k => k.Replace("fc[", "").Replace("]", ""), k => fc[k]);
            if (!names.Any() && string.IsNullOrWhiteSpace(names["Name_Vi"]) || string.IsNullOrWhiteSpace(names["Name_En"]))
            {
                return Json(new
                {
                    Status = 0,
                    Message = Contanst.StringMessage.NameViIsEmpty
                });
            }
            if (!discripitons.Any() && string.IsNullOrWhiteSpace(discripitons["Discription_Vi"]) || string.IsNullOrWhiteSpace(discripitons["Discription_En"]))
            {
                return Json(new
                {
                    Status = 0,
                    Message = Contanst.StringMessage.DescriptionViIsEmpty
                });
            }
            if (isOk)
            {
                var languages = _languageService.GetAll().ToList();
                foreach (var item in languages)
                {
                    model.LanguageVms.Add(new LanguageVm()
                    {
                        LanguageId = item.Id,
                        Value = names.ContainsKey($"{"Name_"}{item.Code}")
                            ? names[$"{"Name_"}{item.Code}"]
                            : string.Empty,
                        Token = "CategoryName"
                    });

                    model.LanguageVms.Add(new LanguageVm()
                    {
                        LanguageId = item.Id,
                        Value = discripitons.ContainsKey($"{"Name_"}{item.Code}")
                            ? discripitons[$"{"Name_"}{item.Code}"]
                            : string.Empty,
                        Token = "CategoryDescription"
                    });
                }
                model.Code = fc["fc[Code]"];
                model.SortOrder = Convert.ToInt32(fc["fc[SortOrder]"]);
                model.Status = fc["fc[Status]"].ToUpper().Equals("TRUE");
                Category e = MapEntity(model, null);
            }
            return Json(new
            {
                Status = 1,
                Message = string.Format(Contanst.StringMessage.AddSuccess, "The Category ")
            });
        }
        public ActionResult Edit()
        {
            return View();
        }

        #region private

        private static Category MapEntity(CategoryCommandModel model, Category entity)
        {
            if (entity == null)
            {
                return new Category
                {
                    Code = model.Code,
                    Status = model.Status,
                    SortOder = model.SortOrder,
                };
            }
            entity.CategoryId = model.CategoryId;
            entity.Code = model.Code;
            entity.Status = model.Status;
            entity.SortOder = model.SortOrder;
            return entity;
        }
        #endregion
    }
}