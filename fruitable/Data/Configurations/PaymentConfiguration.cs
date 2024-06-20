using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fruitable.Data.Models;

namespace Fruitable.Data.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Amount)
                   .HasColumnType("decimal(18,2)") // Defines the database column type for Amount
                   .IsRequired();

            builder.Property(p => p.PaymentDate)
                   .IsRequired();

            builder.Property(p => p.PaymentMethod)
                   .IsRequired()
                   .HasMaxLength(50); // Sets maximum length for PaymentMethod

            // Configure relationship with Order
            builder.HasOne(p => p.Order)
                   .WithMany(o => o.Payments)
                   .HasForeignKey(p => p.OrderId) // Assuming OrderId is the foreign key property
                   .IsRequired();

            // Configure timestamps if applicable
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.ModifiedOn).IsRequired();
        }
    }
}
