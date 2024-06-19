using Fruitable.ViewModels;

namespace Fruitable.Repositry.Home
{
    public interface IHomeRepositry
    {
        Task<List<ProductDetailViewModel>> GetLatestProductDetailViewModelsAsync();
        Task<List<ProductDetailViewModel>> GetTopSellerProductDetailViewModelsAsync();
        Task<List<ProductDetailViewModel>> GetBestRatedProductDetailViewModelsAsync();
    }
}
