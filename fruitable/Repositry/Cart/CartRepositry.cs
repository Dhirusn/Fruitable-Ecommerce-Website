using fruitable.Data;
using Fruitable.Data.Models;
using Fruitable.Utilities;
using Fruitable.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Fruitable.Repositry.Cart
{
    public class CartRepositry : ICartRepositry
    {
        public readonly ApplicationDbContext _context;
        private readonly ConfigurationHelper _configurationHelper;
        public CartRepositry(ApplicationDbContext context, ConfigurationHelper configurationHelper)
        {
            _context = context;
            _configurationHelper = configurationHelper;
        }
        public async Task<Result<bool>> AddToCart(int productId, int quantity)
        {
            try
            {
                var currentUser = await _configurationHelper.GetCurrentUserDetailsAsync();
                var cart = _context.Carts.Include(c => c.CartItems)
                                 .FirstOrDefault(c => c.UserId == currentUser.Id);

                if (cart == null)
                {
                    cart = new Data.Models.Cart
                    {
                        UserId = currentUser.Id,
                        CreatedOn = DateTime.UtcNow,
                        ModifiedOn = DateTime.UtcNow,
                        CartItems = new List<CartItem>()
                    };
                    _context.Carts.Add(cart);
                }
                else
                {
                    cart.ModifiedOn = DateTime.UtcNow;
                }

                // Check if the product already exists in the cart
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

                if (cartItem != null)
                {
                    // Update quantity and modified date
                    cartItem.Quantity += quantity;
                    cartItem.ModifiedOn = DateTime.UtcNow;
                }
                else
                {
                    // Add new cart item
                    cartItem = new CartItem
                    {
                        CartId = cart.Id,
                        ProductId = productId,
                        Quantity = quantity,
                        CreatedOn = DateTime.UtcNow,
                        ModifiedOn = DateTime.UtcNow
                    };
                    _context.CartItems.Add(cartItem);
                }
                _context.SaveChanges();
                return Result<bool>.SuccessResult(true, "cart successfully updated");
            }
            catch (Exception ex)
            {
                return Result<bool>.ErrorResult(ex.Message);
            }
        }

        public async Task<Result<List<CartViewModel>>> GetCurrentUserCartItemList()
        {
            var result = new List<CartViewModel>();
            try
            {
                var currentUser = await _configurationHelper.GetCurrentUserDetailsAsync();

                var carts = _context.Carts.Include(c => c.CartItems)
                                           .ThenInclude(ci => ci.Product)
                                           .Where(c => c.User.Id == currentUser.Id)
                                           .ToList();

                result = carts.Select(c => new CartViewModel
                {
                    CartId = c.Id,
                    UserId = c.User.Id,
                    CreatedOn = c.CreatedOn,
                    ModifiedOn = c.ModifiedOn,
                    CartItems = c.CartItems.Select(ci => new CartItemViewModel
                    {
                        CartItemId = ci.Id,
                        ProductId = ci.Product.Id,
                        ProductName = ci.Product.Name,
                        Price = ci.Product.Price,
                        Quantity = ci.Quantity
                    }).ToList()
                }).ToList();

                return Result<List<CartViewModel>>.SuccessResult(result);
            }
            catch (Exception ex)
            {
                return Result<List<CartViewModel>>.ErrorResult(ex.Message);
            }
        }
    }
}
