using Application.Dtos;
using Domain.Enum;
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

        [HttpGet("paymentWebhook")]
        public async Task<IActionResult> HandlePaymentWebhook()
        {
            var values = Enum.GetValues(typeof(PaymentStatusEnum));
            var random = new Random();
            var teste = values.GetValue(random.Next(values.Length));

            return Ok(teste);
        }
    }
}
