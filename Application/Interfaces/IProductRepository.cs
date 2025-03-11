using ProductService.Application.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Product?> GetByIdAsync(int id);

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <param name="name"></param>
        /// <param name="franchise"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetAllAsync(string? name, string? franchise, string? category);

        /// <summary>
        /// Search for products by name, type, or franchise.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="franchise"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> SearchAsync(string? name, string? type, string? franchise);

        /// <summary>
        /// Get products by Ids
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        Task<List<Product>> GetByIdsAsync(List<int> productIds);
    }
}
