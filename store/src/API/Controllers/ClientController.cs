using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientUseCase _clientUseCase;

        public ClientController(IClientUseCase clientUseCase)
        {
            _clientUseCase = clientUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var clients = await _clientUseCase.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetByCpfAsync(string cpf)
        {
            var client = await _clientUseCase.GetByCpfAsync(cpf);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost("client")]
        public async Task<IActionResult> CreateAsync([FromBody] RequestClientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var client = await _clientUseCase.CreateAsync(dto);

            return Ok(client);
        }
    }
}