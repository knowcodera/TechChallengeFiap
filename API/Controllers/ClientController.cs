using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetByCpfAsync(string cpf)
        {
            var client = await _clientService.GetByCpfAsync(cpf);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost("client")]
        public async Task<IActionResult> CreateAsync([FromBody] RequestClientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var client = await _clientService.CreateAsync(dto);

            return Ok(client);
        }
    }
}