using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindIt.Shared.DTOs
{
    public class SizeResponseDTO
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Size name is required")]
        [StringLength(50, ErrorMessage = "Size name cannot exceed 50 characters")]
        public string SizeName { get; set; }
    }
}
