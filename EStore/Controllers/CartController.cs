using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EStore.Managers;
using EStore.Services;
using EStore.Models.CartViewModels;
using EStore.Models;

namespace EStore.Controllers
{
    public class CartController : Controller
    {

        private readonly ICartManager _cartManager;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public CartController(
            ICartManager cartManager,
            IProductService productService,
            IOrderService orderService
            )
        {
            this._cartManager = cartManager;
            this._productService = productService;
            this._orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model, string returnUrl)
        {

            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var cart = await this._cartManager.GetCartAsync();

                var result = this._orderService.Add(cart, model);

                if (result.Status == Models.ServiceModels.ServiceResultStatus.Success)
                {
                    //successful
                    return RedirectToAction(nameof(OrderController.Details), nameof(OrderController), new { Id =  "id"});
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Couldnt process purchase order!");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult AddToCart(int id)
        {
            var product = this._productService.Find(id);

            if(product != null)
            {
                this._cartManager.AddProduct(product);
            }
            
            var referrer = HttpContext.Request.Headers["Referer"].ToString();
            return Redirect(referrer);
        }

        [HttpGet]
        public IActionResult RemoveFromCart(int id)
        {
            this._cartManager.RemoveCartItem(id, 1);

            var referrer = HttpContext.Request.Headers["Referer"].ToString();
            return Redirect(referrer);
        }

        [HttpGet]
        public IActionResult RemoveAllFromCart(int id)
        {
            this._cartManager.RemoveCartItem(id);

            var referrer = HttpContext.Request.Headers["Referer"].ToString();
            return Redirect(referrer);
        }
    }
}