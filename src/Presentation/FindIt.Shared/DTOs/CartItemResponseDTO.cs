using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FindIt.Shared.DTOs
{

    public class CartItemResponseDTO
    {
        [Required(ErrorMessage = "ProductId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "ProductId must be a positive number.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "ProductName is required.")]
        [StringLength(100, ErrorMessage = "ProductName cannot exceed 100 characters.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "ProductImage is required.")]
        [Url(ErrorMessage = "ProductImage must be a valid URL.")]
        public string ProductImage { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "UnitPrice is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "UnitPrice must be greater than 0.")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "Total is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total must be greater than 0.")]
        public double Total { get; set; }


        [Required(ErrorMessage = "Size is required.")]
        [StringLength(5, ErrorMessage = "Size can only be up to 5 characters long.")]
        public string Size { get; set; }


        [Required(ErrorMessage = "Color is required.")]
        public string Color { get; set; }
    }
}
