namespace Fruitable.Models
{
    public class CartItems
    {
        public int Id { get; set; }
        public Carts Cart { get; set; }
        public Products Product { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
