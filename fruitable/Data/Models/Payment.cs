namespace Fruitable.Data.Models
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public string PaymentMethod { get; set; }

        public Guid OrderId { get; set; } // Foreign key to Order

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedOn { get; set; } = DateTime.UtcNow;

        public virtual Order Order { get; set; }
    }
}
