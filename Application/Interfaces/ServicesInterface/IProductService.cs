using ProductService.Application.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces.ServicesInterface
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(ProductDto productDto);
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(string? name, string? franchise, string? category);
        Task DeleteProductAsync(int id);
        Task<List<ProductDto>> GetProductsByIdsAsync(List<int> productIds);
    }
}
