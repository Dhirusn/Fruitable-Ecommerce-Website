namespace Fruitable.ViewModels
{
    public class CartViewModel
    {
        public Guid CartId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
    }

    public class CartItemViewModel
    {
        public Guid CartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
