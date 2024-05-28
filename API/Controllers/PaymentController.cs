using Application.Dtos;
using Application.Interfaces;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult CreatePayment([FromBody] CreatePaymentDto createPaymentDto)
        {
            var payment = _paymentService.CreatePayment(createPaymentDto);
            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id }, payment);
        }

        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            var payment = _paymentService.GetPaymentById(id);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        [HttpGet("order/{orderId}")]
        public IActionResult GetPaymentsByOrderId(int orderId)
        {
            var payments = _paymentService.GetPaymentsByOrderId(orderId);
            return Ok(payments);
        }

        [HttpPut("{paymentId}")]
        public IActionResult UpdatePayment(int paymentId, [FromBody] PaymentStatus status)
        {
            var payment = _paymentService.UpdatePayment(paymentId, status);
            return Ok(payment);
        }
    }
}
