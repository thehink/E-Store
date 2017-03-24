using EStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EStore.Managers
{
    public interface ICartManager
    {
        Task AddProduct(ClaimsPrincipal user, Product product, int count = 1);

        Task RemoveCartItem(ClaimsPrincipal user, int cartItemId, int count = 0);

        Task<Cart> GetCartAsync(ClaimsPrincipal user);

        Task Empty(ClaimsPrincipal user);
    }
}
