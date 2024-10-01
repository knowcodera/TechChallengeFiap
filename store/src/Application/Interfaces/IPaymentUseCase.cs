using Application.Dtos;

namespace Application.Interfaces
{
    public interface IPaymentUseCase
    {
        //ResponsePaymentDto CreatePayment(CreatePaymentDto createPaymentDto);
        //ResponsePaymentDto UpdatePayment(int paymentId, PaymentStatus status);
        ResponsePaymentDto GetPaymentById(int id);
        IEnumerable<ResponsePaymentDto> GetPaymentsByOrderId(int orderId);
    }
}
