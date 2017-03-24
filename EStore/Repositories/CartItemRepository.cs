using EStore.Data;
using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public class CartItemRepository :  BaseRepository, ICartItemRepository
    {
        public CartItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Add(CartItem cartItem)
        {
            this._context.CartItems.Add(cartItem);
            this._context.SaveChanges();
        }

        public void Update(CartItem cartItem)
        {
            this._context.CartItems.Update(cartItem);
            this._context.SaveChanges();
        }

        public void Remove(int id)
        {
            var cartItem = _context.CartItems.First(p => p.Id == id);
            this._context.CartItems.Remove(cartItem);
            this._context.SaveChanges();
        }

        public CartItem Find(int id)
        {
            return this._context.CartItems.FirstOrDefault(item => item.Id == id);
        }
    }
}
