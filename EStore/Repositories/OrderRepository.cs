using EStore.Data;
using EStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public class OrderRepository : Repository<Order, string>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Order> GetOrdersByEmail(string email)
        {
            return this._context.Include("Items").Where(order => order.Email == email).ToList();
        }
        public IEnumerable<Order> GetOrdersByUserId(string userId)
        {
            return this._context.Include("Items").Where(order => order.UserId == userId).ToList();
        }
        public override Order Find(string id)
        {
            return this._context.Include("Items").FirstOrDefault(order => order.Id == id);
        }
    }
}
