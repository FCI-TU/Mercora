using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FindIt.Shared.DTOs
{

    public class AddressResponseDTO
    {
        [Required(ErrorMessage = "FullName is required.")]
        [StringLength(100, ErrorMessage = "FullName cannot exceed 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        [StringLength(200, ErrorMessage = "Street cannot exceed 200 characters.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Governorate is required.")]
        [StringLength(100, ErrorMessage = "Governorate cannot exceed 100 characters.")]
        public string Governorate { get; set; }

        [Required(ErrorMessage = "PostalCode is required.")]
        [StringLength(10, ErrorMessage = "PostalCode cannot exceed 10 characters.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required.")]
        [Phone(ErrorMessage = "PhoneNumber must be a valid phone number.")]
        public string PhoneNumber { get; set; }
    }
}
