using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces
{
    public interface ICartRepository
    {
        /// <summary>
        /// Get Cart by Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<Cart?> GetCartByEmailAsync(string email);

        /// <summary>
        /// Save Cart in MongoDB
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        Task SaveCartAsync(Cart cart);

        /// <summary>
        /// Delete Cart by Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task DeleteCartAsync(string email);
    }
}
