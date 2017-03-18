using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EStore.Repositories;
using EStore.Models.ProductViewModels;

namespace EStore.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = this._productRepository.GetAll();

            var model = new ProductsViewModel()
            {
                Products = products.ToList()
            };

            return View(model);
        }
    }
}