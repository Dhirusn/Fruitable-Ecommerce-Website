namespace Fruitable.Data.Models
{
    public class Wishlist
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public string UserId { get; set; } // Foreign key to ApplicationUser

        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;
    }
}
