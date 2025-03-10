using ProductService.Application.DTOs;

namespace ProductService.Application.Interfaces.ServicesInterface
{
    public interface ICartService
    {
        public Task AddToCartAsync(CartDto cartDto);
        public Task<CartDto> GetCartAsync(string email);
    }
}
