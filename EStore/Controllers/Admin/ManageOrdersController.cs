using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EStore.Services;
using EStore.Models;
using EStore.Models.Admin.ManageOrdersViewModels;

namespace EStore.Controllers.Admin
{
    public class ManageOrdersController : AdminBaseController
    {

        private readonly IOrderService _orderService;

        public ManageOrdersController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        public IActionResult Index()
        {

            var ordersResult = this._orderService.GetAll();


            return View(ordersResult.Data);
        }


        [HttpPost]
        public IActionResult Status(OrderStatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                var orderResult = this._orderService.Find(model.Id);
                if (orderResult.Succeeded)
                {
                    var order = orderResult.Data;
                    order.Status = model.Status;
                    var updateResult = this._orderService.Update(order);
                }
                
            }


            return RedirectToAction("Index", "ManageOrders");
        }

        public IActionResult Delete(string id)
        {
            var orderResult = this._orderService.Find(id);
            if (orderResult.Succeeded)
            {
                var deleteResult = this._orderService.Remove(orderResult.Data.Id);
            }

            return RedirectToAction("Index", "ManageOrders");
        }
    }
}