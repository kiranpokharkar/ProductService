namespace ProductService.Application.DTOs
{
    public class CartItemDto
    {
        public string ProductId { get; set; }  // MongoDB uses string IDs
        public int Quantity { get; set; }
    }

    public class CartDto
    {
        public string Email { get; set; }
        public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
    }
}
