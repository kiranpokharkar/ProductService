using ProductService.Application.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces.ServicesInterface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task CreateCategoryAsync(CategoryDto categoryDTO);
        Task UpdateCategoryAsync(CategoryDto categoryDTO);
        Task DeleteCategoryAsync(int id);
    }
}
