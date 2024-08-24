using System.ComponentModel.DataAnnotations;

namespace JangaPetStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(10000, ErrorMessage = "Description cannot exceed 10000 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 100000.00, ErrorMessage = "Price must be between $0.01 and $10,000.00.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Stock quantity must be at least 1.")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}
