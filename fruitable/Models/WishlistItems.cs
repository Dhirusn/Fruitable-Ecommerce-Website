namespace Fruitable.Models
{
    public class WishlistItems
    {
        public int Id { get; set; }
        public Wishlists Wishlist { get; set; }
        public Products Product { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
