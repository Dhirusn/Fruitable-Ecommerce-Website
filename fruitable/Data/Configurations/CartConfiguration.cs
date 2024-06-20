using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fruitable.Data.Models;

namespace Fruitable.Data.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);
           builder.Property(c => c.Id).ValueGeneratedOnAdd();

            // Configure relationship with User
            builder.HasOne(c => c.User)
                   .WithOne()
                   .HasForeignKey<Cart>(c => c.UserId)
                   .IsRequired();

            // Configure navigation to CartItems
            builder.HasMany(c => c.CartItems)
                   .WithOne(ci => ci.Cart)
                   .HasForeignKey(ci => ci.CartId)
                   .IsRequired();

            // Configure timestamps
            builder.Property(c => c.CreatedOn)
                   .IsRequired();

            builder.Property(c => c.ModifiedOn)
                   .IsRequired();
        }
    }
}
