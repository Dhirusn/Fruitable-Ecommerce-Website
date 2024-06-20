using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fruitable.Data.Models;

namespace Fruitable.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Description)
                   .HasMaxLength(500);

            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)") // Defines the database column type for Price
                   .IsRequired();

            builder.Property(p => p.ImageURL)
                   .HasMaxLength(255);

            // Optionally, configure relationships if Product has relationships with other entities
            // Example:
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .IsRequired();

            //Configure timestamps if applicable
             builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.ModifiedOn).IsRequired();
        }
    }
}
