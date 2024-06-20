using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fruitable.Data.Models;

namespace Fruitable.Data.Configurations
{
    public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Id)
                   .ValueGeneratedOnAdd();

            builder.HasOne(w => w.User)
                   .WithMany(u => u.Wishlists)
                   .HasForeignKey(w => w.UserId) // Assuming UserId is the foreign key property
                   .IsRequired(); // Ensures that every Wishlist must have a User

            // Optionally, configure other properties if needed
            // Example:
            builder.Property(w => w.CreatedOn).IsRequired();
            builder.Property(w => w.ModifiedOn).IsRequired();
        }
    }
}
