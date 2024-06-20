using fruitable.Data;
using Fruitable.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Fruitable.Repositry.Home
{
    public class HomeRepositry : IHomeRepositry
    {
        public readonly ApplicationDbContext _context;
        public HomeRepositry(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDetailViewModel>> GetBestRatedProductDetailViewModelsAsync()
        {
            var result = new List<ProductDetailViewModel>();
            try
            {
                result = await _context.Products.Select(x => new ProductDetailViewModel
                {
                    Id = x.Id,
                    Category = x.Category!.Name,
                    Description = x.Description,
                    Price = x.Price,
                    ProductName = x.Name,
                    ReviewCount = _context.Reviews.Count(y => y.ProductId == x.Id),
                }).Take(8).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        public async Task<List<ProductDetailViewModel>> GetLatestProductDetailViewModelsAsync()
        {
            var result = new List<ProductDetailViewModel>();
            try
            {
                result = await _context.Products.Select(x => new ProductDetailViewModel
                {
                    Id = x.Id,
                //    Category = x.Category!.Name,
                    Description = x.Description,
                    Price = x.Price,
                    ProductName = x.Name,
                    ReviewCount = _context.Reviews.Count(y => y.ProductId == x.Id),
                }).Take(8).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }

        public async Task<List<ProductDetailViewModel>> GetTopSellerProductDetailViewModelsAsync()
        {
            var result = new List<ProductDetailViewModel>();
            try
            {
                result = await _context.Products.Select(x => new ProductDetailViewModel
                {
                    Id = x.Id,
                 //   Category = x.Category!.Name,
                    Description = x.Description,
                    Price = x.Price,
                    ProductName = x.Name,
                    ReviewCount = _context.Reviews.Count(y => y.ProductId == x.Id),
                }).Take(10).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
    }
}
