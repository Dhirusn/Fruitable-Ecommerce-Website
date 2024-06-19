using fruitable.Data;
using Fruitable.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Fruitable.Repositry.Shop
{
    public class ShopRepositry : IShopRepositry
    {
        public readonly ApplicationDbContext _context;
        public ShopRepositry(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProductDetailViewModel> GetProductDetails(int productId)
        {
            var result = new ProductDetailViewModel();
            try
            {
                var product = await _context.Products
                            .FirstOrDefaultAsync(x => x.Id == productId);

                if (product != null)
                {
                    var review = _context.Reviews.Where(x=>x.ProductID == productId).Select(x => new ReviewViewModel
                    {
                        ProductID = x.ProductID,
                        Comment = x.Comment,
                        CreatedOn = x.CreatedOn,
                        ModifiedOn = x.ModifiedOn,
                        Rating = x.Rating,
                        User = x.User,
                        Id = x.Id.ToString(),
                    }).ToList();

                    result.Id = product.Id;
                    result.ProductName = product.Name;
                    result.Price = product.Price;
                    result.Description = product.Description;
                    // result.Category = product.Category!.Name!;

                    result.Reviews = review;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return result;
        }
    }
}
