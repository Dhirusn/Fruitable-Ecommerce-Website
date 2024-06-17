using System.ComponentModel.DataAnnotations;

namespace Fruitable.Models
{
    public class Review
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int ProductID { get; set; }
        public Products Product { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }
    }
}
