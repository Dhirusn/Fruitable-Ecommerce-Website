namespace Fruitable.ViewModels
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; } 
        public string ProductName { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int ReviewCount {  get; set; }
        public List<ReviewViewModel>? Reviews { get; set; }
    }
}
