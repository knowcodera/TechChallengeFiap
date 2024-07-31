using Domain.Enum;

namespace Application.Dtos
{
    public class CreatePaymentDto
    {
        public int OrderId { get; set; }
    }

    public class ResponsePaymentDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }

    public class PaymentDto
    {
        public DateTime PaymentDate { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public int OrderId { get; set; }
    }
}
