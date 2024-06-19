using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fruitable.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult AddToCart(int productId, int quantity)
        {
            return Json(new { success = true, message = "Product added to cart successfully!" });
        }
    }
}
