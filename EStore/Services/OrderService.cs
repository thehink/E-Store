using EStore.Models;
using EStore.Models.CartViewModels;
using EStore.Models.ServiceModels;
using EStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public ServiceResult<Order> Find(string id)
        {
            return new ServiceResult<Order>(() =>
            {
                return this._orderRepository.Find(id);
            });
        }

        public ServiceResultCollection<Order> GetOrdersByEmail(string email)
        {
            return new ServiceResultCollection<Order>(() =>
            {
                return this._orderRepository.GetOrdersByEmail(email).ToList();
            });
        }

        public ServiceResult Add(Order order)
        {
            return new ServiceResult(() =>
            {
                this._orderRepository.Add(order);
            });
        }
    }
}
