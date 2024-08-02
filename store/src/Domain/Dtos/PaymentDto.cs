namespace Domain.Dtos
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
}
