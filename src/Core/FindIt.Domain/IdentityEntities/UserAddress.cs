using FindIt.Domain.Common;
using FindIt.Domain.IdentityEntities;



namespace FindIt.Domain
{
    public class UserAddress : BaseEntity
    {
        public string AdressName { get; set; } = null!;
        public string AdressLine { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Governate { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public int UserId { get; set; }
        public required AppUser AppUser { get; set; }
    }
}