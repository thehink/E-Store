using EStore.Models;
using EStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EStore.Managers
{
    public class CartManager : ICartManager
    {

        private readonly IHttpContextAccessor _context;
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CartManager(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IHttpContextAccessor context,
            ICartRepository cartRepository,
            ICartItemRepository cartItemRepository)
        {
            this._context = context;
            this._cartRepository = cartRepository;
            this._cartItemRepository = cartItemRepository;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        public async Task RemoveCartItem(ClaimsPrincipal userClaim, int cartItemId, int count = 0)
        {
            var cart = await this.GetCartAsync(userClaim);

            var cartItem = cart.Items.FirstOrDefault(c => c.Id == cartItemId);

            if(cartItem == null)
            {
                return;
            }

            if(count == 0 || cartItem.Count - count <= 0)
            {
                //cart.Items.Remove(cartItem);
                this._cartItemRepository.Remove(cartItem.Id);
            }
            else
            {
                cartItem.Count -= count;
                this._cartItemRepository.Update(cartItem);
            }

            //this._cartRepository.Update(cart);
        }

        public async Task AddProduct(ClaimsPrincipal userClaim, Product product, int count = 1)
        {
            var cart = await this.GetCartAsync(userClaim);

            var cartItem = cart.Items.FirstOrDefault(c => c.Product.Id == product.Id);

            if(cartItem == null)
            {
                cartItem = new CartItem()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Product = product,
                    Cart = cart,
                    Count = count,
                };

                this._cartItemRepository.Add(cartItem);
            }
            else
            {
                cartItem.Count += count;
                this._cartItemRepository.Update(cartItem);
            }
        }

        private async Task<Cart> CreateNewCartAsync(ClaimsPrincipal userClaim)
        {
            var user = await GetCurrentUserAsync(userClaim);

            var cart = new Cart()
            {
                User = user,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            this._cartRepository.Add(cart);

            return cart;
        }

        public async Task Empty(ClaimsPrincipal userClaim)
        {
            var cart = await this.GetCartAsync(userClaim);

            cart.Items.Clear();

            this._cartRepository.Update(cart);
        }

        public async Task<Cart> GetCartAsync(ClaimsPrincipal userClaim)
        {
            var signedIn = this._signInManager.IsSignedIn(userClaim);

            string cartId = this._context.HttpContext.Request.Cookies["cartId"];

            if (signedIn)
            {
                var user = await this.GetCurrentUserAsync(userClaim);
                var userCart = this._cartRepository.FindCartByUserId(user.Id);

                if (userCart != null)
                {
                    return userCart;
                }

                
                
                //populate new cart with products of old cart
                if (!string.IsNullOrEmpty(cartId))
                {
                    var findCart = this._cartRepository.Find(cartId);
                    if (findCart != null)
                    {
                        findCart.UserId = user.Id;
                        this._cartRepository.Update(findCart);

                        this._context.HttpContext.Response.Cookies.Append("cartId", findCart.Id.ToString(), new CookieOptions() { Expires = new DateTimeOffset() });
                        return findCart;
                    }
                }

                var newCart = await CreateNewCartAsync(userClaim);
                return newCart;
            }

            if(!string.IsNullOrEmpty(cartId))
            {
                var findCart = this._cartRepository.Find(cartId);
                if(findCart != null)
                {
                    return findCart;
                }
            }

            var cart = await CreateNewCartAsync(userClaim);

            var cookieOptions = new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(30)
            };
            this._context.HttpContext.Response.Cookies.Append("cartId", cart.Id.ToString(), cookieOptions);
            return cart;
        }

        private Task<ApplicationUser> GetCurrentUserAsync(ClaimsPrincipal userClaim)
        {
            return _userManager.GetUserAsync(userClaim);
        }
    }
}
