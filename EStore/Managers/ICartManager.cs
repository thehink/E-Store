using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Managers
{
    public interface ICartManager
    {
        Task AddProduct(Product product, int count = 1);
        Task RemoveCartItem(int cartItemId, int count = 0);
        Task<Cart> GetCartAsync();
    }
}
