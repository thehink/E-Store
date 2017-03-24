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
            var order = this._orderRepository.Find(id);

            return new ServiceResult<Order>()
            {
                Status = order == null ? ServiceResultStatus.Error : ServiceResultStatus.Success,
                Data = order,
                Message = order == null ? "could not find order" : null
            };
        }

        public ServiceResultCollection<Order> GetOrdersByEmail(string email)
        {
            var orders = this._orderRepository.GetOrdersByEmail(email).ToList();

            return new ServiceResultCollection<Order>()
            {
                Status = ServiceResultStatus.Success,
                Data = orders,
            };
        }

        public ServiceResult Add(Order order)
        {
            this._orderRepository.Add(order);

            return new ServiceResult()
            {
                Status = ServiceResultStatus.Success,
            };
        }
    }
}
