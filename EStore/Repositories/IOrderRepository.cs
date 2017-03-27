using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public interface IOrderRepository : IRepository<Order, string>
    {
        IEnumerable<Order> GetOrdersByEmail(string email);
        IEnumerable<Order> GetOrdersByUserId(string userId);
    }
}
