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
            var categories = _categoryService.List();
            var categoryViewModel = categories.Select(x => new CategoryViewModel{
                CategoryId = x.CategoryId,
                Code = x.Code,
                ContentDefinition = x.ContentDefinition,
                SortOrder = x.SortOder,
                CreatedDate = x.CreatedDate,
                CreatedBy = x.CreatedBy,
                ModifiedBy = x.ModifiedBy,
                ModifiedDate = x.ModifiedDate,
            });
            var lang = _languageService.List();
            ViewBag.Languages = lang;
            return View(categoryViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryViewModel model, FormCollection fc)
        {
            var isOk = true;
            var names = fc.AllKeys
                .Where(x => x.StartsWith("fc[Name_"))
                .ToDictionary(k => k.Replace("fc[", "").Replace("]", ""), k => fc[k]);
            var discripitons = fc.AllKeys
                .Where(x => x.StartsWith("fc[Description_"))
                .ToDictionary(k => k.Replace("fc[", "").Replace("]", ""), k => fc[k]);
            if (!names.Any() && string.IsNullOrWhiteSpace(names["Name_Vi"]) || string.IsNullOrWhiteSpace(names["Name_En"]))
            {
                return Json(new
                {
                    Status = 0,
                    Message = Contanst.StringMessage.NameViIsEmpty
                });
            }
            if (!discripitons.Any() && string.IsNullOrWhiteSpace(discripitons["Description_Vi"]) || string.IsNullOrWhiteSpace(discripitons["Description_En"]))
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
                        Value = discripitons.ContainsKey($"{"Description_"}{item.Code}")
                            ? discripitons[$"{"Description_"}{item.Code}"]
                            : string.Empty,
                        Token = "CategoryDescription"
                    });
                }
                model.Code = fc["fc[Code]"];
                model.SortOrder = Convert.ToInt32(fc["fc[SortOrder]"]);
                model.Status = fc["fc[Status]"].ToUpper().Equals("TRUE");
            }
            Category e = MapEntity(model, null);

            e.CreatedBy = "Admin";
            e.CreatedDate = DateTime.Now;
            e.ModifiedBy = "Admin";
            e.ModifiedDate = DateTime.Now;
            var created = _categoryService.Create(model, e);
            return created
                ? Json(new
                {
                    Status = 1,
                    Message = string.Format(Contanst.StringMessage.AddSuccess, "The Category ")
                })
                : Json(new
            {
                Status = 1,
                Message = string.Format("Lỗi trong quá trình xử lý dữ liệu.Vui lòng liên hệ Admin.")
            });
        }
        public ActionResult Edit()
        {
            return View();
        }

        #region private

        private static Category MapEntity(CategoryViewModel model, Category entity)
        {
            if (entity == null)
            {
                return new Category
                {
                    CategoryId = Guid.NewGuid(),
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