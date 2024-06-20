using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Fruitable.Data.Models;
using Fruitable.Data.Configurations;

namespace fruitable.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define DbSet properties for each entity
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply entity configurations
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());
            modelBuilder.ApplyConfiguration(new WishlistConfiguration());
            modelBuilder.ApplyConfiguration(new WishlistItemConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());

            // Add other configurations here as needed

            // Global query filters (optional)
            // Example: filter out soft-deleted items
            // modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);

            // Seed initial data (optional)
            // Example: seeding categories
            // modelBuilder.Entity<Category>().HasData(
            //     new Category { Id = 1, Name = "Category 1" },
            //     new Category { Id = 2, Name = "Category 2" }
            // );

            // Customize model conventions (optional)
            // Example: set default value for CreatedOn and ModifiedOn properties
            // foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            // {
            //     entityType.SetProperty("CreatedOn", typeof(DateTime));
            //     entityType.SetProperty("ModifiedOn", typeof(DateTime));
            // }

            // Customize model validation (optional)
            // Example: configure default values or validation rules
            // modelBuilder.Entity<Product>()
            //     .Property(p => p.Price)
            //     .IsRequired()
            //     .HasColumnType("decimal(18,2)")
            //     .HasDefaultValue(0.00);

            // Apply any other global configurations or customizations

            // Ensure to call base.OnModelCreating at the end if overridden
            // base.OnModelCreating(modelBuilder);
        }
    }
}
