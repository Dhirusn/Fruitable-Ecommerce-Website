namespace Fruitable.Models
{
    public class Payments
    {
        public Guid Id { get; set; } = new Guid();
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public Orders Order { get; set; }
    }
}
