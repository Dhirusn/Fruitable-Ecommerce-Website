using System.ComponentModel.DataAnnotations;

namespace Fruitable.Data.Models
{
    public class Review
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public int ProductId { get; set; } // Foreign key to Product

        [Required]
        public string UserId { get; set; } // Foreign key to ApplicationUser

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;

        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
