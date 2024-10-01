using Application.Dtos;
using Application.Interfaces;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderUseCase _orderUseCase;

        public OrderController(IOrderUseCase orderUseCase)
        {
            _orderUseCase = orderUseCase;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            var order = _orderUseCase.CreateOrder(createOrderDto);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderUseCase.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderUseCase.GetOrderById(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateOrderStatus(int id, [FromBody] OrderStatus status)
        {
            var order = _orderUseCase.UpdateOrderStatus(id, status);
            if (order == null)
                return NotFound();

            return Ok(order);
        }
    }
}
