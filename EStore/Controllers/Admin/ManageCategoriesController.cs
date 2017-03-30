using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EStore.Services;
using EStore.Models.Admin.ManageCategoriesViewModels;
using EStore.Models;

namespace EStore.Controllers.Admin
{
    public class ManageCategoriesController : AdminBaseController
    {

        private readonly ICategoryService _categoryService;

        public ManageCategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = this._categoryService.GetAll();

            var model = new ListCategoriesViewModel()
            {
                Categories = categories.Data
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categoryResult = this._categoryService.Find(id);

            if(categoryResult.Status == Models.ServiceModels.ServiceResultStatus.Error)
            {
                return NotFound();
            }

            var category = categoryResult.Data;

            var model = new EditCategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var categoryResult = this._categoryService.Find(model.Id);

            if (categoryResult.Status == Models.ServiceModels.ServiceResultStatus.Error)
            {
                ModelState.AddModelError("Error", "You tried editing a category that does not exist");
                return View(model);
            }

            var category = categoryResult.Data;

            category.Name = model.Name;

            var result = this._categoryService.Update(category);

            if(result.Status == Models.ServiceModels.ServiceResultStatus.Error)
            {
                ModelState.AddModelError("Error", "Could not edit category");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new EditCategoryViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EditCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var category = new Category()
            {
                Name = model.Name
            };

            var result = this._categoryService.Create(category);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("Error", result.Message);
                return View();
            }

            return RedirectToAction("Index", "ManageCategories");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = this._categoryService.Remove(id);

            if (result.Succeeded)
            {
                
            }

            return RedirectToAction("Index", "ManageCategories");
        }
    }
}