using System.ComponentModel.DataAnnotations;

namespace ProductService.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }  // For Get operation

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
        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Product type is required.")]
        [StringLength(50, ErrorMessage = "Product type can't be longer than 50 characters.")]
        public string Type { get; set; } = string.Empty;

        // Foreign Keys (make optional)
        public int? CategoryId { get; set; } // Now optional
        public int? FranchiseId { get; set; } // Now optional

        // Navigation properties for mapping
        public CategoryDto? Category { get; set; } // Nullable if not provided
        public FranchiseDto? Franchise { get; set; } // Nullable if not provided
    }
}
