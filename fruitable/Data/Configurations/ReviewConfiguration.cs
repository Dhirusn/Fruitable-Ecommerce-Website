using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fruitable.Data.Models;

namespace Fruitable.Data.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(r => r.Rating)
                   .IsRequired()
                   .HasDefaultValue(1); // Sets a default value for Rating if not provided

            builder.Property(r => r.Comment)
                   .HasMaxLength(1000); // Limits the length of the Comment field to 1000 characters

            builder.Property(r => r.ReviewDate)
                   .IsRequired(); // Ensures that ReviewDate is a required field
                                  //Configure timestamps if applicable
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.ModifiedOn).IsRequired();
        }
    }
}
