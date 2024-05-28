using Domain.Enum;

namespace Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public void Update(PaymentStatus status)
        {
            Status = status;
        }
    }
}
