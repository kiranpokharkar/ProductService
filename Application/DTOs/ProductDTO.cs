namespace ProductService.Application.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; } = string.Empty; // Blob Storage URL
        public string Type { get; set; }  // New field
        public string Franchise { get; set; }  // New field

        // Foreign Key (CategoryId)
        public int CategoryId { get; set; }
    }
}
