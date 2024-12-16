using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FindIt.Shared.DTOs
{
    public class OrderItemResponseDTO
    {
        [Required(ErrorMessage = "ProductId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "ProductId must be a positive number.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "UnitPrice is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "UnitPrice must be greater than 0.")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "Total is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total must be greater than 0.")]
        public double Total { get; set; }
    }
}
