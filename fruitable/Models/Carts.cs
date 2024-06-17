namespace Fruitable.Models
{
    public class Carts
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<CartItems> CartItems { get; set; }
    }
}
