using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fruitable.Data.Models;

namespace Fruitable.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100); // Adjusted max length to 100 based on typical naming lengths

            builder.Property(c => c.CreatedOn)
                   .IsRequired(); // Assuming you have CreatedOn and ModifiedOn properties

            builder.Property(c => c.ModifiedOn)
                   .IsRequired();

            // Optionally, configure relationships if Category has relationships with other entities
            // Example:
            builder.HasMany(c => c.Products)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId)
                   .IsRequired();
        }
    }
}
