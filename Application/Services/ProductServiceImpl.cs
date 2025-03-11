using AutoMapper;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces.ServicesInterface;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;

namespace ProductService.Application.Services
{
    public class ProductServiceImpl : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductServiceImpl(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
        {
            if (productDto == null)
            {
                throw new ArgumentNullException(nameof(productDto));
            }

            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);

            // Return the newly created product as a DTO
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with id {id} not found.");
            }

            return _mapper.Map<ProductDto>(product);
        }


        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(string? name, string? franchise, string? category)
        {
            var products = await _productRepository.GetAllAsync(name, franchise, category);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                await _productRepository.DeleteAsync(product);
            }
        }
        public async Task<List<ProductDto>> GetProductsByIdsAsync(List<int> productIds)
        {
            var products = await _productRepository.GetByIdsAsync(productIds);
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task UpdateStockAsync(int productId, int quantityChange)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) throw new Exception($"Product {productId} not found.");

            product.Stock += quantityChange;
            await _productRepository.UpdateAsync(product);
        }
    }
}
