using Microsoft.AspNetCore.Mvc;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;
using ProductService.Application.Interfaces.ServicesInterface;
using ProductService.Domain.Entities;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<FranchiseController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<FranchiseController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {

            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();

                if (categories == null || !categories.Any())
                {
                    return NoContent();
                }

                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all franchises.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var categories = await _categoryService.GetCategoryByIdAsync(id);

            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto categoryDTO)
        {
            await _categoryService.CreateCategoryAsync(categoryDTO);
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryDTO.Id }, categoryDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
