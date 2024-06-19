using Fruitable.ViewModels;

namespace Fruitable.Repositry.Shop
{
    public interface IShopRepositry
    {
       Task<ProductDetailViewModel> GetProductDetails(int productId);
    }
}
