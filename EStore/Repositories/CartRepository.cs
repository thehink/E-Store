using EStore.Data;
using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public class CartRepository : BaseRepository, ICartRepository
    {
        public CartRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Add(Cart cart)
        {
            this._context.Carts.Add(cart);
            this._context.SaveChanges();
        }

        public Cart GetCartByUserId(string userId)
        {
            return this._context.Carts.FirstOrDefault(c => c.UserId.Id == userId);
        }


        public Cart Find(int id)
        {
            return this._context.Carts.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Update(Cart cart)
        {
            this._context.Carts.Update(cart);
            this._context.SaveChanges();
        }

        public void Remove(int id)
        {
            var cart = _context.Carts.First(p => p.Id == id);
            this._context.Carts.Remove(cart);
            this._context.SaveChanges();
        }
    }
}
