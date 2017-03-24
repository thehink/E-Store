using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EStore.Services;
using EStore.Models.OrderViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using EStore.Models;

namespace EStore.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            this._orderService = orderService;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string Id)
        {

            var orderResult = this._orderService.Find(Id);

            if(orderResult.Status == Models.ServiceModels.ServiceResultStatus.Error)
            {
                return NotFound();
            }

            var model = new OrderDetailsViewModel()
            {
                Order = orderResult.Data
            };

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> MyOrders()
        {
            var user = await this._userManager.GetUserAsync(this.User);
            var ordersResult = this._orderService.GetOrdersByEmail(user.Email);

            var model = new MyOrdersViewModel()
            {
                Orders = ordersResult.Data
            };

            return View(model);
        }
    }
}