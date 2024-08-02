using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentUseCase _paymentUseCase;

        public PaymentController(IPaymentUseCase paymentUseCase)
        {
            _paymentUseCase = paymentUseCase;
        }


        //inutil porque a ordem cria o pagamento
        //[HttpPost]
        //public IActionResult CreatePayment([FromBody] CreatePaymentDto createPaymentDto)
        //{
        //    var payment = _paymentUseCase.CreatePayment(createPaymentDto);
        //    return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id }, payment);
        //}

        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            var payment = _paymentUseCase.GetPaymentById(id);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        [HttpGet("order/{orderId}")]
        public IActionResult GetPaymentsByOrderId(int orderId)
        {
            var payments = _paymentUseCase.GetPaymentsByOrderId(orderId);
            return Ok(payments);
        }


        //[HttpPut("{paymentId}")]
        //public IActionResult UpdatePayment(int paymentId, [FromBody] PaymentStatus status)
        //{
        //    var payment = _paymentUseCase.UpdatePayment(paymentId, status);
        //    return Ok(payment);
        //}
    }
}
