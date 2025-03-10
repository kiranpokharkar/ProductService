using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task SaveOrderAsync(Order order);
        Task<List<Order>> GetOrdersByEmailAsync(string email);
    }
}
