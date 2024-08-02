using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using System.Net.Http.Json;

namespace Application.UseCases
{
    public class OrderUseCase : IOrderUseCase
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentRepository _paymentRepository;


        public OrderUseCase(IMapper mapper, IOrderRepository orderRepository, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _paymentRepository = paymentRepository;
        }

        public ResponseOrderDto CreateOrder(CreateOrderDto createOrderDto)
        {
            var httpClient = new HttpClient();
            var paymentWebhookUrl = "http://apipayment:8480/v1/Payment/paymentWebhook";

            var response = httpClient.GetAsync(paymentWebhookUrl).Result;

            var status = response.Content.ReadFromJsonAsync<PaymentStatus>().Result;

            if (status == PaymentStatus.Recusado)
            {
                return new ResponseOrderDto();
            }

            var order = new Order
            {
                CreatedAt = DateTime.UtcNow,
                Status = OrderStatus.Recebido,
                ClientId = createOrderDto.ClientId,
                Items = _mapper.Map<List<OrderItem>>(createOrderDto.Items)
            };

            _orderRepository.Add(order);
            _orderRepository.SaveChanges();

            var payment = new Payment
            {
                PaymentDate = DateTime.UtcNow,
                Status = status,
                OrderId = order.Id
            };

            _paymentRepository.Add(payment);
            _paymentRepository.SaveChanges();


            return _mapper.Map<ResponseOrderDto>(order);
        }

        public IEnumerable<ResponseOrderDto> GetAllOrders()
        {
            var orders = _orderRepository.GetAll();
            return _mapper.Map<IEnumerable<ResponseOrderDto>>(orders);
        }

        public ResponseOrderDto GetOrderById(int id)
        {
            var order = _orderRepository.GetById(id);
            return _mapper.Map<ResponseOrderDto>(order);
        }

        public ResponseOrderDto UpdateOrderStatus(int id, OrderStatus status)
        {
            var order = _orderRepository.GetById(id);
            if (order == null) return null;

            order.Status = status;
            _orderRepository.Update(order);
            _orderRepository.SaveChanges();

            return _mapper.Map<ResponseOrderDto>(order);
        }
    }
}
