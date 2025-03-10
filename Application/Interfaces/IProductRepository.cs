using ProductService.Application.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product?> GetByIdAsync(int id);

        Task<IEnumerable<Product>> GetAllAsync(string? name, string? franchise, string? category);

        Task<IEnumerable<Product>> SearchAsync(string? name, string? type, string? franchise);

        Task<List<Product>> GetByIdsAsync(List<int> productIds);
    }
}
