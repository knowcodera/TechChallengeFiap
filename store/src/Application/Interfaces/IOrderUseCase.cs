using Application.Dtos;
using Domain.Enum;

namespace Application.Interfaces
{
    public interface IOrderUseCase
    {
        ResponseOrderDto CreateOrder(CreateOrderDto createOrderDto);
        IEnumerable<ResponseOrderDto> GetAllOrders();
        ResponseOrderDto GetOrderById(int id);
        ResponseOrderDto UpdateOrderStatus(int id, OrderStatus status);
    }
}
