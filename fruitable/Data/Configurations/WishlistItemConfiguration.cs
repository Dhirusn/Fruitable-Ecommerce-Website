using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fruitable.Data.Models;

namespace Fruitable.Data.Configurations
{
    public class WishlistItemConfiguration : IEntityTypeConfiguration<WishlistItem>
    {
        public void Configure(EntityTypeBuilder<WishlistItem> builder)
        {
            builder.HasKey(wi => wi.Id);

            //builder.Property(wi => wi.Id)
            //       .ValueGeneratedOnAdd();

            // Configure relationship with Wishlist
            builder.HasOne(wi => wi.Wishlist)
                   .WithMany(w => w.WishlistItems)
                   .HasForeignKey(wi => wi.WishlistId) // Assuming WishlistId is the foreign key property
                   .IsRequired(); // Ensures that every WishlistItem must be associated with a Wishlist

            // Configure relationship with Product
            builder.HasOne(wi => wi.Product)
                   .WithMany() // Assuming WishlistItem references Product, and Product does not reference WishlistItem directly
                   .HasForeignKey(wi => wi.ProductId) // Assuming ProductId is the foreign key property in WishlistItem
                   .IsRequired(); // Ensures that every WishlistItem must be associated with a Product

            // Optionally, configure other properties if needed
            // Example:
            builder.Property(wi => wi.CreatedOn).IsRequired();
            builder.Property(wi => wi.ModifiedOn).IsRequired();
        }
    }
}
