using System;
using MezbanAirKitchen.Controllers;
using MezbanService.Interfaces;
using System.Web.Mvc;
using System.Web.Services.Description;
using MezbanCommon.Heplers;
using MezbanData.DbContext;
using MezbanModel.Category;
using Microsoft.Owin.Security.Provider;

namespace MezbanAirKitchen.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ILanguageService languageService, IAspNetUserService aspNetUserService, ICategoryService categoryService) : base(languageService, aspNetUserService)
        {
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryCommandModel model)
        {
            var category = MapEntity(model, null);
            category.CreatedDate = DateTime.Now;
            category.CreatedBy = "Admin";
            category.ModifiedDate = DateTime.Now;
            category.ModifiedBy = "Admin";

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