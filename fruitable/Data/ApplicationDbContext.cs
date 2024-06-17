using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Fruitable.Models;

namespace fruitable.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Wishlists> Wishlists { get; set; }
        public DbSet<WishlistItems> WishlistItems { get; set; }
        public DbSet<Payments> Payments { get; set; }
    }
}
