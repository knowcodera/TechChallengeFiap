using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;

namespace Application.UseCases
{
    public class PaymentUseCase : IPaymentUseCase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public PaymentUseCase(IPaymentRepository paymentRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        //public ResponsePaymentDto CreatePayment(CreatePaymentDto createPaymentDto)
        //{
        //    var order = _orderRepository.GetById(createPaymentDto.OrderId);
        //    if (order == null)
        //        throw new ArgumentException("Order not found");

        //    var payment = new Payment
        //    {
        //        PaymentDate = DateTime.UtcNow,
        //        Status = PaymentStatus.Pendente,
        //        OrderId = createPaymentDto.OrderId
        //    };

        //    _paymentRepository.Add(payment);
        //    _paymentRepository.SaveChanges();


        //    return _mapper.Map<ResponsePaymentDto>(payment);
        //}

        //public ResponsePaymentDto UpdatePayment(int paymentId, PaymentStatus status)
        //{
        //    var payment = _paymentRepository.GetById(paymentId);
        //    if (payment == null)
        //        throw new ArgumentException("Payment not found");

        //    payment.Update(status);

        //    _paymentRepository.Update(payment);
        //    _paymentRepository.SaveChanges();

        //    if(payment.Status == PaymentStatus.Pago)
        //    {
        //        var order = _orderRepository.GetById(payment.OrderId);
        //        order.Status = OrderStatus.EmPreparacao;
        //        _orderRepository.Update(order);
        //        _orderRepository.SaveChanges();
        //    }

        //    return _mapper.Map<ResponsePaymentDto>(payment);
        //}

        public ResponsePaymentDto GetPaymentById(int id)
        {
            var payment = _paymentRepository.GetById(id);
            return _mapper.Map<ResponsePaymentDto>(payment);
        }

        public IEnumerable<ResponsePaymentDto> GetPaymentsByOrderId(int orderId)
        {
            var payments = _paymentRepository.GetByOrderId(orderId);
            return _mapper.Map<IEnumerable<ResponsePaymentDto>>(payments);
        }
    }
}
