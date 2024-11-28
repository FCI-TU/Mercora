using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindIt.Shared.DTOs
{
    public class ProductResponseDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Product description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }


        [Range(0.01, double.MaxValue, ErrorMessage = "Discounted price must be greater than 0")]
        public decimal DiscountedPrice { get; set; }


        [Required(ErrorMessage = "Stock quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be greater than or equal to 0")]
        public int StockQuantity { get; set; }


        [Required(ErrorMessage = "Brand ID is required")]
        public string BrandName { get; set; }


        [Required(ErrorMessage = "Category ID is required")]
        public string CategoryName { get; set; }


        [Required(ErrorMessage = "Size IDs are required")]
        public List<SizeResponseDTO> Sizes { get; set; }


        [Required(ErrorMessage = "Color ID is required")]
        public ColorResponseDTO Color { get; set; }


        public DateTime CreatedAt { get; set; }


        [Required(ErrorMessage = "Product status is required")]
        [StringLength(20, ErrorMessage = "Status cannot exceed 20 characters")]
        public string Status { get; set; }


        public IFormFile ImageUrl { get; set; }  // URL of the product image

    }

}
