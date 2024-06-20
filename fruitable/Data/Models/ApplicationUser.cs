using Microsoft.AspNetCore.Identity;

namespace Fruitable.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Additional properties can be added here if needed
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public int CardNumber { get; set; }
        public int OTP { get; set; }
        public DateTime OTPExpiration { get; set; }
        public DateTime DOB { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
