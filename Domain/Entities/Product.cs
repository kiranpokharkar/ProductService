namespace ProductService.Domain.Entities
{
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; } = string.Empty; // Blob Storage URL
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Type { get; set; }  // New field
    public string Franchise { get; set; }  // New field

    // Foreign Key
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
}
