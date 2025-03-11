using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;
using ProductService.Application.Interfaces.ServicesInterface;
using ProductService.Application.Services;
using ProductService.Domain.Entities;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IBlobService _blobStorageService;
        public ProductController(IProductService productService, IBlobService blobStorageService)
        {
            _productService = productService;
            _blobStorageService = blobStorageService;
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="productDto">The data transfer object containing product details.</param>
        /// <returns>The newly created product with its generated ID.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductDto createProductDto)
        {
            if (createProductDto == null)
            {
                return BadRequest("Product data is required.");
            }

            if (createProductDto.ProductImage == null || createProductDto.ProductImage.Length == 0)
            {
                return BadRequest("File is required.");
            }

            //  Generate unique filename
            var fileName = $"{Guid.NewGuid()}_{createProductDto.ProductImage.FileName}";

            //  Upload image to blob storage
            using var stream = createProductDto.ProductImage.OpenReadStream();
            var image_url= await _blobStorageService.UploadFileAsync(stream, fileName, createProductDto.ProductImage.ContentType);

            //  Convert DTO to actual Product entity
            var productDto = new ProductDto
            {
                Name = createProductDto.Name,
                FranchiseId = createProductDto.FranchiseId,
                Price = createProductDto.Price,
                Stock = createProductDto.Stock,
                CategoryId = createProductDto.CategoryId,
                ImageUrl = image_url
            };

            var createdProduct = await _productService.CreateProductAsync(productDto);

            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }



        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The product if found, otherwise NotFound.</returns>
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

        /// <summary>
        /// Retrieves all products with optional filtering by name, franchise, or category.
        /// </summary>
        /// <param name="name">The name of the product to filter.</param>
        /// <param name="franchise">The franchise name to filter.</param>
        /// <param name="category">The category name to filter.</param>
        /// <returns>A list of matching products.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? name, [FromQuery] string? franchise, [FromQuery] string? category)
        {
            var products = await _productService.GetAllProductsAsync(name, franchise, category);
            return Ok(products);
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the product to be deleted.</param>
        /// <returns>NoContent response if the deletion is successful.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent(); // 204 No Content (successful deletion)
        }

    }
}
