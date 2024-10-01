using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductUseCase _productUseCase;

        public ProductController(IProductUseCase productService)
        {
            _productUseCase = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var Products = await _productUseCase.GetAllAsync();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Product = await _productUseCase.GetByIdAsync(id);

            if (Product == null)
                return NotFound();

            return Ok(Product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RequestProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _productUseCase.CreateAsync(dto);

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] RequestProductDto dto)
        {
            var product = await _productUseCase.UpdateProduct(id, dto);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productUseCase.DeleteProduct(id);

            return NoContent();
        }
    }
}
