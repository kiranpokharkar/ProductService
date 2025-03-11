using ProductService.Application.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces.ServicesInterface
{
    public interface ICategoryService
    {
        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();

        /// <summary>
        /// Get Cart by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CategoryDto> GetCategoryByIdAsync(int id);

        /// <summary>
        /// Create new Category
        /// </summary>
        /// <param name="categoryDTO"></param>
        /// <returns></returns>
        Task CreateCategoryAsync(CategoryDto categoryDTO);

        /// <summary>
        /// Uodate existing category
        /// </summary>
        /// <param name="categoryDTO"></param>
        /// <returns></returns>
        Task UpdateCategoryAsync(CategoryDto categoryDTO);

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteCategoryAsync(int id);
    }
}
