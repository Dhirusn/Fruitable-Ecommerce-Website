using Microsoft.AspNetCore.Identity;

namespace Fruitable.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Additional properties can be added here if needed
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ZipCode {  get; set; } = string.Empty;
        public int CardNumber { get; set; }
        public int OTP { get; set; }
        public DateTime OTPExpiration { get; set; }
        public DateTime DOB { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Carts> Carts { get; set; }
        public ICollection<Wishlists> Wishlists { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
