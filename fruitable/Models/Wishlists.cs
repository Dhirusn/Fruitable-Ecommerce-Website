namespace Fruitable.Models
{
    public class Wishlists
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<WishlistItems> WishlistItems { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
