using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductService.Application.Interfaces.ServicesInterface;
using ProductService.Application;
using ProductService.Domain.Entities;
using ProductService.Application.Interfaces;
using System.Security.Authentication;

namespace ProductService.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _orderCollection;

        public OrderRepository(IOptions<MongoDbSettings> settings)
        {
            var mongoSettings = MongoClientSettings.FromUrl(new MongoUrl(settings.Value.ConnectionString));
            mongoSettings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };

            var client = new MongoClient(mongoSettings);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _orderCollection = database.GetCollection<Order>("Orders");
        }

        public async Task SaveOrderAsync(Order order)
        {
            await _orderCollection.InsertOneAsync(order);
        }

        public async Task<List<Order>> GetOrdersByEmailAsync(string email)
        {
            return await _orderCollection.Find(o => o.Email == email).ToListAsync();
        }
    }
}
