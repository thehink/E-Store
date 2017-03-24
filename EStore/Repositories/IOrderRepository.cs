using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void Remove(string id);
        void Update(Order order);
        IEnumerable<Order> GetOrdersByEmail(string email);
        IEnumerable<Order> GetOrdersByUserId(string userId);
        Order Find(string id);
    }
}
