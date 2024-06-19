using Fruitable.Repositry.Home;
using Fruitable.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace fruitable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IHomeRepositry _homeRepositry;
        public HomeController(ILogger<HomeController> logger,IHomeRepositry homeRepositry)
        {
            _logger = logger;
            _homeRepositry = homeRepositry;
        }

        public async Task<IActionResult> Index()
        {
            var latestProductList =await _homeRepositry.GetLatestProductDetailViewModelsAsync();
            var topSellerProductList = await _homeRepositry.GetTopSellerProductDetailViewModelsAsync();
            var bestRatedProductList = await _homeRepositry.GetBestRatedProductDetailViewModelsAsync();
            var model = Tuple.Create(latestProductList,topSellerProductList,bestRatedProductList);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
