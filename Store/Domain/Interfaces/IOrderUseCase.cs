using Domain.Dtos;
using Domain.Enum;

namespace Domain.Interfaces
{
    public interface IOrderUseCase
    {
        ResponseOrderDto CreateOrder(CreateOrderDto createOrderDto);
        IEnumerable<ResponseOrderDto> GetAllOrders();
        ResponseOrderDto GetOrderById(int id);
        ResponseOrderDto UpdateOrderStatus(int id, OrderStatus status);
    }
}
