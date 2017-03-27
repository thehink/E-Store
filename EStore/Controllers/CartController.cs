using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EStore.Managers;
using EStore.Services;
using EStore.Models.CartViewModels;
using EStore.Models;
using EStore.Models.ServiceModels;

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutViewModel model, string returnUrl)
        {

            ViewData["ReturnUrl"] = returnUrl;

            var cart = await this._cartManager.GetCartAsync(this.User);

            if (cart.Items.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "You need at least some items to create order!");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    Status = OrderStatus.Idle,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Address = model.Address,
                    CreatedAt = DateTime.Now,
                    User = cart.User,
                    Items = cart.Items.Select(cartItem => {
                        return new OrderItem()
                        {
                            Name = cartItem.Name,
                            Price = cartItem.Price,
                            Count = cartItem.Count,
                            Product = cartItem.Product,
                            CreatedAt = DateTime.Now
                        };
                    }).ToList()
                };

                var result = this._orderService.Add(order);

                if (result.Status == ServiceResultStatus.Success)
                {
                    //successful
                    //clear cart
                    await this._cartManager.Empty(this.User);

                    //redirect to order reciept
                    return RedirectToAction(nameof(OrderController.Details), "Order", new { Id = order.Id });
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
        public async Task<IActionResult> AddToCart(int id)
        {
            var productResult = this._productService.Find(id);

            if(productResult.Status == ServiceResultStatus.Success)
            {
                await this._cartManager.AddProduct(this.User, productResult.Data);
            }
            
            var referrer = HttpContext.Request.Headers["Referer"].ToString();
            return Redirect(referrer);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            await this._cartManager.RemoveCartItem(this.User, id, 1);

            var referrer = HttpContext.Request.Headers["Referer"].ToString();
            return Redirect(referrer);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveAllFromCart(int id)
        {
            await this._cartManager.RemoveCartItem(this.User, id);

            var referrer = HttpContext.Request.Headers["Referer"].ToString();
            return Redirect(referrer);
        }
    }
}