using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartByEmailAsync(string email);
        Task SaveCartAsync(Cart cart);
    }
}
