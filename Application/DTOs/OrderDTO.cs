using MongoDB.Bson.Serialization.Attributes;

namespace ProductService.Application.DTOs
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderDto
    {
        public string Email { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
        public decimal TotalOrderAmount { get; set; }
    }
}
