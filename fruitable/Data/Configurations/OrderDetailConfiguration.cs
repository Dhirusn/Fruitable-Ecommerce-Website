using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fruitable.Data.Models;

namespace Fruitable.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.Id);

            builder.Property(od => od.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(od => od.Price)
                   .HasColumnType("decimal(18,2)") // Defines the database column type for Price
                   .IsRequired();

            // Configure relationships if OrderDetail has relationships with other entities
            // Example:
            builder.HasOne(od => od.Order)
                   .WithMany(o => o.OrderDetails)
                   .HasForeignKey(od => od.OrderId)
                   .IsRequired();

            // Configure navigation properties if needed
            // Example:
            builder.Navigation(od => od.Product)
                   .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            //Configure timestamps if applicable
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.ModifiedOn).IsRequired();
        }
    }
}
