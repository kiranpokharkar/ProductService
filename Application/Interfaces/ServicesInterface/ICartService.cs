using ProductService.Application.DTOs;

namespace ProductService.Application.Interfaces.ServicesInterface
{
    public interface ICartService
    {
        /// <summary>
        /// Add to Cart
        /// </summary>
        /// <param name="cartDto"></param>
        /// <returns></returns>
        public Task AddToCartAsync(CartDto cartDto);

        /// <summary>
        /// Get Cart details
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<CartDto> GetCartAsync(string email);

        /// <summary>
        /// Clear cart
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task ClearCartAsync(string email);
    }
}
