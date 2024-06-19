using Fruitable.Repositry.Shop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fruitable.Controllers
{
    public class ShopController : Controller
    {
        public readonly IShopRepositry _shopRepositry;
        public ShopController(IShopRepositry shopRepositry)
        {
            _shopRepositry = shopRepositry;
        }

        // GET: ShopController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShopController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _shopRepositry.GetProductDetails(id);
            return View(result);
        }

        // GET: ShopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
