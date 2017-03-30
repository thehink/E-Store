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

        ServiceResult Remove(string id);

        ServiceResult Update(Order order);

        ServiceResultCollection<Order> GetOrdersByEmail(string email);

        ServiceResultCollection<Order> GetAll();

        ServiceResult<Order> Find(string id);
    }
}
