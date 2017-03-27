using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EStore.Repositories;
using EStore.Models.ProductViewModels;
using EStore.Services;

namespace EStore.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            int category, page;
            int.TryParse(this.HttpContext.Request.Query["category"], out category);
            int.TryParse(this.HttpContext.Request.Query["page"], out page);
            string query = this.HttpContext.Request.Query["q"];

            var productsResult = this._productService.Search(query, category, page, 10);
            var categoriesResult = this._productService.GetCategories();

            var model = new ProductsViewModel()
            {
                CategoryId = category,
                Query = this.HttpContext.Request.Query["q"],
                Categories = categoriesResult.Data,
                Products = productsResult.Data,
                Page = productsResult.Page,
                Limit = productsResult.Limit,
                Results = productsResult.Results
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var productResult = this._productService.Find(id);

            if (!productResult.Succeeded)
            {
                return NotFound();
            }

            var model = new ProductDetailsViewModel()
            {
                Product = productResult.Data
            };

            return View(model);
        }
    }
}