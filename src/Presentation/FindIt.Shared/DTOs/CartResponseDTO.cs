using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindIt.Shared.DTOs
{
    public class CartResponseDTO
    {
        [Required(ErrorMessage = "UserId is required.")]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "CartId is required.")]
        public int CartId { get; set; }

        [Required(ErrorMessage = "CartItems are required.")]
        public List<CartItemResponseDTO> CartItems { get; set; }
    }
}
