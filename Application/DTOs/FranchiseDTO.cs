using System.ComponentModel.DataAnnotations;

namespace ProductService.Application.DTOs
{
    public class FranchiseDto
    {
        public int Id { get; set; }  // For Get operation

        [Required(ErrorMessage = "Franchise name is required.")]
        [StringLength(100, ErrorMessage = "Franchise name can't be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
