using System.ComponentModel.DataAnnotations;

namespace ProductService.Domain.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }  // Primary Key, Auto-Incremented by DB

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name can't be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string? Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property for products
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
