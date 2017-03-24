using EStore.Data;
using EStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Add(Order order)
        {
            this._context.Orders.Add(order);
            this._context.SaveChanges();
        }
        public void Remove(string id)
        {
            var order = _context.Orders.First(p => p.Id == id);
            this._context.Orders.Remove(order);
            this._context.SaveChanges();
        }
        public void Update(Order order)
        {
            this._context.Orders.Update(order);
            this._context.SaveChanges();
        }
        public IEnumerable<Order> GetOrdersByEmail(string email)
        {
            return this._context.Orders.Include("OrderItems").Where(order => order.Email == email).ToList();
        }
        public IEnumerable<Order> GetOrdersByUserId(string userId)
        {
            return this._context.Orders.Include("OrderItems").Where(order => order.UserId == userId).ToList();
        }
        public Order Find(string id)
        {
            return this._context.Orders.Include("OrderItems").FirstOrDefault(order => order.Id == id);
        }
    }
}
