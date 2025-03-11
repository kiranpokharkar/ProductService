using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        /// <summary>
        /// Get Category by Id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Category?> GetByNameAsync(string name);
    }
}
