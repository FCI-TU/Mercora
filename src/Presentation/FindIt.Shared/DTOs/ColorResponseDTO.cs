using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FindIt.Shared.DTOs
{
    public class ColorResponseDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Color name is required")]
        [StringLength(50, ErrorMessage = "Color name cannot exceed 50 characters")]
        public string ColorName { get; set; }


        [Required(ErrorMessage = "Hex code is required")]
        [StringLength(7, ErrorMessage = "Hex code must be 7 characters long")]
        [RegularExpression(@"^#(?:[0-9a-fA-F]{3}){1,2}$", ErrorMessage = "Invalid Hex color code format")]
        public string HexCode { get; set; }
    }
}
