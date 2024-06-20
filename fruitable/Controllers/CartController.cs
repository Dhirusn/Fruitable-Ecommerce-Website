using Fruitable.Repositry.Cart;
using Fruitable.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fruitable.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        public readonly ICartRepositry _cartRepositry;
        public CartController(ICartRepositry cartRepositry)
        {
            _cartRepositry = cartRepositry;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _cartRepositry.GetCurrentUserCartItemList();
            return View(result.Data);
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var result = await _cartRepositry.AddToCart(productId, quantity);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
