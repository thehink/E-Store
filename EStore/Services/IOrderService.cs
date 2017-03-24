using EStore.Models;
using EStore.Models.CartViewModels;
using EStore.Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Services
{
    public interface IOrderService
    {
        ServiceResult Add(Order order);

        ServiceResultCollection<Order> GetOrdersByEmail(string email);

        ServiceResult<Order> Find(string id);
    }
}
