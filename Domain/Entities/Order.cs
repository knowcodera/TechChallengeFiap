using Domain.Enum;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public int ClientId { get; set; } 
        public Client Client { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public ICollection<Payment> Payments { get; set; }

    }
}
