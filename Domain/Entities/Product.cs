using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductService.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }  // Primary Key, Auto-Incremented by DB

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(255, ErrorMessage = "Product name can't be longer than 255 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Description can't be longer than 1000 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative integer.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [Url(ErrorMessage = "Image URL must be a valid URL.")]
        public string ImageUrl { get; set; } = string.Empty;  // Blob Storage URL

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Keys with [ForeignKey] annotations
        [ForeignKey("Category")]
        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }

        [ForeignKey("Franchise")]
        [Required(ErrorMessage = "Franchise ID is required.")]
        public int FranchiseId { get; set; }

        // Navigation properties
        public Category Category { get; set; } = null!;
        public Franchise Franchise { get; set; } = null!;
    }

}
