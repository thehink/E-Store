using EStore.Data;
using EStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public class CartRepository : Repository<Cart, string>, ICartRepository
    {
        public CartRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Cart FindCartByUserId(string userId)
        {
            return this._context.Include("Items").FirstOrDefault(c => c.User.Id == userId);
        }

        public override Cart Find(string id)
        {
            return this._context.Include("Items").FirstOrDefault(c => c.Id == id);
        }
    }
}
