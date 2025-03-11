using ProductService.Application.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces.ServicesInterface
{
    public interface IOrderService
    {
        /// <summary>
        /// Place order
        /// </summary>
        /// <param name="orderDto"></param>
        /// <returns></returns>
        Task PlaceOrderAsync(OrderDto orderDto);

        /// <summary>
        /// Get order by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<List<Order>> GetOrdersByUserAsync(string email);
    }
}
