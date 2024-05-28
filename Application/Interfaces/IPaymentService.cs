using Application.Dtos;
using Domain.Enum;

namespace Application.Interfaces
{
    public interface IPaymentService
    {
        ResponsePaymentDto CreatePayment(CreatePaymentDto createPaymentDto);
        ResponsePaymentDto UpdatePayment(int paymentId, PaymentStatus status);
        ResponsePaymentDto GetPaymentById(int id);
        IEnumerable<ResponsePaymentDto> GetPaymentsByOrderId(int orderId);
    }
}
