using AutoMapper;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;
using ProductService.Application.Interfaces.ServicesInterface;
using ProductService.Domain.Entities;

namespace ProductService.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public CartService(ICartRepository cartRepository, IMapper mapper, IProductService productService)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task AddToCartAsync(CartDto cartDto)
        {
            // Fetch all product IDs from the DTO
            var productIds = cartDto.Items.Select(i => int.Parse(i.ProductId)).ToList();

            // Get product details from ProductService
            var validProducts = await _productService.GetProductsByIdsAsync(productIds);

            // Check if all provided product IDs are valid
            var validProductIds = validProducts.Select(p => p.Id).ToHashSet();
            var invalidProductIds = productIds.Except(validProductIds).ToList();

            if (invalidProductIds.Any())
            {
                throw new ArgumentException($"Invalid product IDs: {string.Join(", ", invalidProductIds)}");
            }

            // Validate quantity for each product
            foreach (var cartItem in cartDto.Items)
            {
                var product = validProducts.First(p => p.Id == int.Parse(cartItem.ProductId));
                if (cartItem.Quantity > product.Stock)
                {
                    throw new ArgumentException($"Insufficient stock for Product ID {cartItem.ProductId}");
                }
            }

            // Map and save to repository
            var cart = _mapper.Map<Cart>(cartDto);
            await _cartRepository.SaveCartAsync(cart);
        }

        public async Task ClearCartAsync(string email)
        {
            await _cartRepository.DeleteCartAsync(email);

        }

        public async Task<CartDto> GetCartAsync(string email)
        {
            var cart = await _cartRepository.GetCartByEmailAsync(email);
            return _mapper.Map<CartDto>(cart);
        }
    }
}
