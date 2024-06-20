using Fruitable.Utilities;
using Fruitable.ViewModels;

namespace Fruitable.Repositry.Cart
{
    public interface ICartRepositry
    {
        Task<Result<bool>> AddToCart(int productId, int quatinty);
        Task<Result<List<CartViewModel>>> GetCurrentUserCartItemList();
    }
}
