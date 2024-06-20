namespace Fruitable.Data.Models
{
    public class WishlistItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid WishlistId { get; set; } // Foreign key to Wishlist
        public int ProductId { get; set; } // Foreign key to Product

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;

        public virtual Wishlist Wishlist { get; set; }
        public virtual Product Product { get; set; }
    }
}
