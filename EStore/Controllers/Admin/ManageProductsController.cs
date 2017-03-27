using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EStore.Services;
using EStore.Models.Admin.ManageProductsViewModels;
using EStore.Models;
using EStore.Utils;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace EStore.Controllers.Admin
{
    public class ManageProductsController : AdminBaseController
    {

        private readonly IProductService _productService;
        private readonly IHostingEnvironment _environment;

        public ManageProductsController(IHostingEnvironment environment, IProductService productService)
        {
            this._environment = environment;
            this._productService = productService;
        }

        public async Task<IActionResult> Index()
        {

            var products = this._productService.GetAll();

            var model = new ListProductsViewModel()
            {
                Products = products.Data
            };

            return View(model);
        }

        public async Task<IActionResult> Details()
        {
            return View();
        }

        public async Task<IActionResult> Create()
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
        public async Task<IActionResult> Create(EditProductViewModel model)
        {
            var categories = this._productService.GetCategories().Data;
            model.Categories = categories;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var uploads = Path.Combine(this._environment.WebRootPath, "uploads");

            string imagePath = "";

            if (model.FileInput != null && model.FileInput.Length > 0)
            {
                if (!model.IsImage())
                {
                    ModelState.AddModelError("Error", "Invalid image!");
                    return View(model);
                }
                imagePath = await SaveImageHelper.SaveImage(model.FileInput, uploads);
            }

            var product = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Public = model.Public,
                CategoryId = model.CategoryId,
                Image = imagePath,
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

        private string SaveImage(string uploads)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> Edit(int id)
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
                Image = product.Image,
                Public = product.Public,
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProductViewModel model)
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
                ModelState.AddModelError("Error", "Could not get the product");
                return View(model);
            }

            var uploads = Path.Combine(this._environment.WebRootPath, "uploads");

            string imagePath = "";

            if (model.FileInput != null && model.FileInput.Length > 0)
            {
                if (!model.IsImage())
                {
                    ModelState.AddModelError("Error", "Invalid image!");
                    return View(model);
                }
                imagePath = await SaveImageHelper.SaveImage(model.FileInput, uploads);
            }

            

            var product = productResult.Data;

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Public = model.Public;
            product.CategoryId = model.CategoryId;

            if (!string.IsNullOrEmpty(imagePath))
            {
                product.Image = imagePath;
            }

            var result = this._productService.Update(product);

            return RedirectToAction("Edit", "ManageProducts", new { id = product.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
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