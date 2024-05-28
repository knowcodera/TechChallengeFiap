using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("product")]
        public async Task<IActionResult> GetAllAsync()
        {
            var Products = await _productService.GetAllAsync();
            return Ok(Products);
        }

        [HttpGet]
        [Route("product/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Product = await _productService.GetByIdAsync(id);

            if (Product == null)
                return NotFound();

            return Ok(Product);
        }

        [HttpPost("product")]
        public async Task<IActionResult> CreateAsync([FromBody] RequestProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = await _productService.CreateAsync(dto);

            return Ok(product);
        }

        [HttpPut("product/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] RequestProductDto dto)
        {
            var product = await _productService.UpdateProduct(id, dto);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpDelete("product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);

            return NoContent();
        }
    }
}
