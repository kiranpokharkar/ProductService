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

        public async Task DeleteCartAsync(string email)
        {
            var filter = Builders<Cart>.Filter.Eq(c => c.Email, email);
            await _cartCollection.DeleteOneAsync(filter);
        }

        public async Task<Cart?> GetCartByEmailAsync(string email)
        {
            return await _cartCollection.Find(c => c.Email == email).FirstOrDefaultAsync();
        }

        public async Task SaveCartAsync(Cart cart)
        {
            var filter = Builders<Cart>.Filter.Eq(c => c.Email, cart.Email);

            var update = Builders<Cart>.Update
                .Set(c => c.Email, cart.Email)
                .Set(c => c.Items, cart.Items);

            var options = new FindOneAndUpdateOptions<Cart>
            {
                IsUpsert = true, // Insert if not found
                ReturnDocument = ReturnDocument.After
            };

            await _cartCollection.FindOneAndUpdateAsync(filter, update, options);
        }

    }
}
