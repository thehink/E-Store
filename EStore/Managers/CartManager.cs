using EStore.Models;
using EStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EStore.Managers
{
    public class CartManager : ICartManager
    {

        private readonly IHttpContextAccessor _context;
        private readonly ICartRepository _cartRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CartManager(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor context,
            ICartRepository cartRepository)
        {
            this._context = context;
            this._cartRepository = cartRepository;
            this._userManager = userManager;
            this._signInManager = signInManager;

            
        }

        private void Get()
        {

        }

        private async Task AddProduct(Product product, int count = 1)
        {
            var cart = await this.GetCartAsync();

            var cartItem = cart.Items.FirstOrDefault(c => c.Product.Id == product.Id);

            if(cartItem == null)
            {
                cartItem = new CartItem()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Product = product,
                    Count = 0,
                };
                cart.Items.Add(cartItem);
            }

            cartItem.Count += count;
            this._cartRepository.Update(cart);
        }

        private void UpdateCartItem(CartItem cartItem)
        {

        }

        private async void test()
        {
            var user = await this.GetCurrentUserAsync();
        }

        private async Task<Cart> GetCartAsync()
        {
            var signedIn = this._signInManager.IsSignedIn(this._context.HttpContext.User);
            
            if(signedIn)
            {
                var user = await this.GetCurrentUserAsync();
                return user.Cart;
            }
            var cartId = this._context.HttpContext.Session.GetInt32("cartId");
            if (cartId == null)
            {
                var cart = new Cart();
                this._cartRepository.Add(cart);
                this._context.HttpContext.Session.SetInt32("cartId", cart.Id);
                return cart;
            }

            var findCart = this._cartRepository.Find((int)cartId);

            return findCart;
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(this._context.HttpContext.User);
        }
    }
}
