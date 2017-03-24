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

        public IActionResult Index()
        {
            int cat;
            int.TryParse(this.HttpContext.Request.Query["category"], out cat);
            string query = this.HttpContext.Request.Query["q"];

            var productsResult = this._productService.FilterProducts(query, cat);
            var categoriesResult = this._productService.GetCategories();

            var model = new ProductsViewModel()
            {
                CategoryId = cat,
                Query = this.HttpContext.Request.Query["q"],
                Categories = categoriesResult.Data,
                Products = productsResult.Data,
            };

            return View(model);
        }

        public IActionResult Search()
        {
            //this.HttpContext.Request.Query
            return View();
        }
    }
}