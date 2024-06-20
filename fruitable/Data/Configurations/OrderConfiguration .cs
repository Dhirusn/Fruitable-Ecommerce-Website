using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fruitable.Data.Models;

namespace Fruitable.Data.Configurations
{

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(o => o.OrderDate)
                   .IsRequired();

            builder.Property(o => o.TotalAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            // Configure relationships if Order has relationships with other entities
            builder.HasMany(o => o.OrderDetails) // Assuming OrderDetails is the navigation property
                   .WithOne(od => od.Order)
                   .HasForeignKey(od => od.OrderId)
                   .IsRequired();

            // Configure navigation properties if needed
            // Example:
            builder.Navigation(o => o.OrderDetails)
                   .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            // Configure timestamps if applicable
            builder.Property(o => o.CreatedOn)
                   .IsRequired();

            builder.Property(o => o.ModifiedOn)
                   .IsRequired();
        }
    }
}
