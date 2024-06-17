using Fruitable.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fruitable.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x=>x.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.Rating)
                   .IsRequired()
                   .HasDefaultValue(1);

            builder.Property(r => r.Comment)
                   .HasMaxLength(1000);

            builder.Property(r => r.ReviewDate)
                   .IsRequired();
        }
    }
}
