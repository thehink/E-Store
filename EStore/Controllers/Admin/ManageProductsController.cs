using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EStore.Services;
using EStore.Models.Admin.ManageProductsViewModels;
using EStore.Models;

namespace EStore.Controllers.Admin
{
    public class ManageProductsController : AdminBaseController
    {

        private readonly IProductService _productService;

        public ManageProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        public IActionResult Index()
        {

            var products = this._productService.FilterProducts();

            var model = new ListProductsViewModel()
            {
                Products = products.Data
            };

            return View(model);
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Create()
        {
            var categories = this._productService.GetCategories().Data;

            var model = new EditProductViewModel()
            {
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EditProductViewModel model)
        {
            var categories = this._productService.GetCategories().Data;
            model.Categories = categories;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Public = model.Public,
                CategoryId = model.CategoryId,
                CreatedAt = DateTime.Now
            };

            var result = this._productService.Create(product);

            if(result.Status == Models.ServiceModels.ServiceResultStatus.Success)
            {
                return RedirectToAction("Index", "ManageProducts", null);
            }
            else
            {
                ModelState.AddModelError("Error", result.Message);
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var product = this._productService.Find(id).Data;
            var categories = this._productService.GetCategories().Data;

           var model = new EditProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Price = product.Price,
                Public = product.Public,
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditProductViewModel model)
        {
            var categories = this._productService.GetCategories().Data;

            model.Categories = categories;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var productResult = this._productService.Find(model.Id);

            if(productResult.Status == Models.ServiceModels.ServiceResultStatus.Error)
            {
                ModelState.AddModelError("Error", "Could not update the product");
                return View(model);
            }

            var product = productResult.Data;

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Public = model.Public;
            product.CategoryId = model.CategoryId;

            this._productService.Update(product);

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var result = this._productService.Remove(id);

            if (result.Status == Models.ServiceModels.ServiceResultStatus.Error)
            {
                return NotFound();
            }

            return RedirectToAction("Index", "ManageProducts", null);
        }
    }
}