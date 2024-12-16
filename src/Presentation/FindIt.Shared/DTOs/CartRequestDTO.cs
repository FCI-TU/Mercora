using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FindIt.Shared.DTOs
{
    public class CartRequestDTO
    {
        [Required(ErrorMessage = "UserId is required.")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "CartId is required.")]
        public int CartId { get; set; }

        [Required(ErrorMessage = "CartItems are required.")]
        public List<CartItemRequestDTO> CartItems { get; set; }
    }
}
