using ProductService.Application.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces.ServicesInterface
{
    public interface IProductService
    {
        /// <summary>
        /// Create a new product.
        /// </summary>
        /// <param name="productDto"></param>
        /// <returns></returns>
        Task<ProductDto> CreateProductAsync(ProductDto productDto);

        /// <summary>
        /// Get a product by its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductDto> GetProductByIdAsync(int id);

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="franchise"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(string? name, string? franchise, string? category);

        /// <summary>
        /// Delete a product by its Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteProductAsync(int id);

        /// <summary>
        /// Get products by Ids.
        /// </summary>
        /// <param name="productIds"></param>
        /// <returns></returns>
        Task<List<ProductDto>> GetProductsByIdsAsync(List<int> productIds);

        /// <summary>
        /// update Stock for product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantityChange"></param>
        /// <returns></returns>
        Task UpdateStockAsync(int productId, int quantityChange);
    }
}
