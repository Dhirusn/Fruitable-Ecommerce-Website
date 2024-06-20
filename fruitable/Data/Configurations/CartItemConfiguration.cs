using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fruitable.Data.Models;

namespace Fruitable.Data.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id).ValueGeneratedOnAdd();

            // Configure relationship with Cart
            builder.HasOne(ci => ci.Cart)
                   .WithMany(c => c.CartItems)
                   .HasForeignKey(ci => ci.CartId)
                   .IsRequired();

            // Configure relationship with Product
            builder.HasOne(ci => ci.Product)
                   .WithMany()
                   .HasForeignKey(ci => ci.ProductId)
                   .IsRequired();

            // Configure Quantity
            builder.Property(ci => ci.Quantity)
                   .IsRequired();

            // Configure timestamps if necessary
            builder.Property(ci => ci.CreatedOn).IsRequired();
            builder.Property(ci => ci.ModifiedOn).IsRequired();
        }
    }
}
