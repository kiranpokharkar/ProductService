using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;

namespace ProductService.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // ✅ Get All Categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }

        // ✅ Create Category
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name
            };

            await _categoryRepository.AddAsync(category);
            return CreatedAtAction(nameof(GetAll), new { id = category.Id }, categoryDto);
        }
        // ✅ Get Category by Name
        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var category = await _categoryRepository.GetByNameAsync(name);
            if (category == null) return NotFound();
            return Ok(category);
        }
    }
}
