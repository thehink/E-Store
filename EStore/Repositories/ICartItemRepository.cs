using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Repositories
{
    public interface ICartItemRepository
    {
        void Add(CartItem cartItem);

        void Update(CartItem cartItem);

        void Remove(int id);

        CartItem Find(int id);
    }
}
