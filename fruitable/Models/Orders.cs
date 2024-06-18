using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fruitable.Models
{
    public class Orders
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ApplicationUser User { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 100000.00)]
        public decimal TotalAmount { get; set; }

        public ICollection<Payments> Payments { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
