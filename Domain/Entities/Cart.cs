using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductService.Domain.Entities
{
    public class Cart
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("items")]
        public List<CartItem> Items { get; set; } = new();
    }

    public class CartItem
    {
        [BsonElement("productId")]
        public int ProductId { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }
    }
}
