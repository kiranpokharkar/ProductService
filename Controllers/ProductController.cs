using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;
using ProductService.Application.Interfaces.ServicesInterface;
using ProductService.Domain.Entities;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // ✅ Create Product
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Product data is required.");
            }

            var createdProduct = await _productService.CreateProductAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }

        // ✅ Get Product by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                return Ok(product);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ✅ Get All Products
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? name, [FromQuery] string? franchise, [FromQuery] string? category)
        {
            var products = await _productService.GetAllProductsAsync(name, franchise, category);
            return Ok(products);
        }

        [HttpDelete("{publicId}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);

            return NoContent(); // 204 No Content (successful deletion)
        }
    }
}
