using Fruitable.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fruitable.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(od => od.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();
        }
    }
}
