using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductService.Application;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;
using System.Security.Authentication;

namespace ProductService.Infrastructure.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly IMongoCollection<Cart> _cartCollection;

        public CartRepository(IOptions<MongoDbSettings> settings)
        {
            var mongoSettings = MongoClientSettings.FromUrl(new MongoUrl(settings.Value.ConnectionString));
            mongoSettings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };

            var client = new MongoClient(mongoSettings);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _cartCollection = database.GetCollection<Cart>("Carts");
        }
        public async Task<Cart?> GetCartByEmailAsync(string email)
        {
            return await _cartCollection.Find(c => c.Email == email).FirstOrDefaultAsync();
        }

        public async Task SaveCartAsync(Cart cart)
        {
            var existingCart = await GetCartByEmailAsync(cart.Email);
            if (existingCart != null)
            {
                await _cartCollection.ReplaceOneAsync(c => c.Email == cart.Email, cart);
            }
            else
            {
                await _cartCollection.InsertOneAsync(cart);
            }
        }
    }
}
