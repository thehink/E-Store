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

        public async Task RemoveCartItem(int cartItemId, int count = 0)
        {
            var cart = await this.GetCartAsync();

            var cartItem = cart.Items.FirstOrDefault(c => c.Id == cartItemId);

            if(cartItem == null)
            {
                return;
            }

            if(count == 0 || cartItem.Count - count <= 0)
            {
                cart.Items.Remove(cartItem);
            }
            else
            {
                cartItem.Count -= count;
            }

            this._cartRepository.Update(cart);
        }

        private async Task<Cart> CreateNewCartAsync()
        {
            var user = await GetCurrentUserAsync();

            var cart = new Cart()
            {
                User = user,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            this._cartRepository.Add(cart);

            return cart;
        }

        public async Task AddProduct(Product product, int count = 1)
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

            if(cartItem.Count >= 999)
            {
                cartItem.Count = 999;
            }

            this._cartRepository.Update(cart);
        }

        public async Task<Cart> GetCartAsync()
        {
            var signedIn = this._signInManager.IsSignedIn(this._context.HttpContext.User);

            if (signedIn)
            {
                var user = await this.GetCurrentUserAsync();
                var userCart = this._cartRepository.FindCartByUserId(user.Id);

                if (userCart != null)
                {
                    return userCart;
                }

                var newCart = await CreateNewCartAsync();
                return newCart;
            }

            int cartId;// = this._context.HttpContext.Session.GetInt32("cartId");
            var cartIdStr = this._context.HttpContext.Request.Cookies["cartId"];

            int.TryParse(cartIdStr, out cartId);

            if(cartId != 0)
            {
                var findCart = this._cartRepository.Find(cartId);
                if(findCart != null)
                {
                    return findCart;
                }
            }

            var cart = await CreateNewCartAsync();

            var cookieOptions = new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(30)
            };
            this._context.HttpContext.Response.Cookies.Append("cartId", cart.Id.ToString(), cookieOptions);
            return cart;
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(this._context.HttpContext.User);
        }
    }
}
