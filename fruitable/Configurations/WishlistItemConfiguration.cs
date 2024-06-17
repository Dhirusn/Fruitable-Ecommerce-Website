using Fruitable.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fruitable.Configurations
{
    public class WishlistItemConfiguration : IEntityTypeConfiguration<WishlistItems>
    {
        public void Configure(EntityTypeBuilder<WishlistItems> builder)
        {
            builder.HasKey(wi => wi.Id);
            builder.Property(wi => wi.Id).ValueGeneratedOnAdd();
            builder.HasOne(wi => wi.Wishlist).WithMany(w => w.WishlistItems).HasForeignKey(wi => wi.Id);
            builder.HasOne(wi => wi.Product).WithMany().HasForeignKey(wi => wi.Id);
        }
    }
}
