using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Save order in MongoDB
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task SaveOrderAsync(Order order);

        /// <summary>
        /// Get orders by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<List<Order>> GetOrdersByEmailAsync(string email);
    }
}
