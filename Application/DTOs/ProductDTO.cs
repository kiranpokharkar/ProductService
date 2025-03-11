using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductService.Application.DTOs
{
    public class ProductDto
    {
        [BindNever]
        public int Id { get; set; }  // For Get operation

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(255, ErrorMessage = "Product name can't be longer than 255 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(10000, ErrorMessage = "Description can't be longer than 1000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative integer.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Image URL is required.")]
        [Url(ErrorMessage = "Image URL must be a valid URL.")]

        [BindNever]
        public string ImageUrl { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        // Foreign Keys (make optional)
        public int? CategoryId { get; set; } // Now optional
        public int? FranchiseId { get; set; } // Now optional

        IFormFile productImage { get; set; }

        // Navigation properties for mapping
        [BindNever]
        public CategoryDto? Category { get; set; } // Nullable if not provided

        [BindNever]
        public FranchiseDto? Franchise { get; set; } // Nullable if not provided
    }

    public class CreateProductDto
    {
        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(255, ErrorMessage = "Product name can't be longer than 255 characters.")]
        [DefaultValue("SRH")]
        public string Name { get; set; }
        [DefaultValue("")]
        [StringLength(10000, ErrorMessage = "Description can't be longer than 1000 characters.")]
        public string? Description { get; set; }

        [DefaultValue(100)]
        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; } = 0;

        [DefaultValue(10)]
        [Required(ErrorMessage = "Stock is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be a non-negative integer.")]
        public int Stock { get; set; } = 0;

        public DateTime CreatedAt { get; set; }

        // Foreign Keys (make optional)
        [Required(ErrorMessage = "CategoryId is required.")]
        public int CategoryId { get; set; } // Now optional

        [Required(ErrorMessage = "FranchiseId is required.")]
        public int FranchiseId { get; set; } // Now optional

        [Required(ErrorMessage = "ProductImage is required.")]
        public IFormFile ProductImage { get; set; }
        
    }
}
