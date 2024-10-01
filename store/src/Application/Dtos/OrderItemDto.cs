namespace Application.Dtos
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateOrderDto
    {
        public List<OrderItemDto> Items { get; set; }
        public int ClientId { get; set; }
    }

    public class ResponseOrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public List<ResponseOrderItemDto> Items { get; set; }
        public List<ResponsePaymentDto> Payments { get; set; }
    }

    public class ResponseOrderItemDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
