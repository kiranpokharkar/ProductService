using ProductService.Application.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces.ServicesInterface
{
    public interface IOrderService
    {
        Task PlaceOrderAsync(OrderDto orderDto);
        Task<List<Order>> GetOrdersByUserAsync(string email);
    }
}
