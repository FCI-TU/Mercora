

using FindIt.Domain.Common;

namespace FindIt.Domain
{
    public class ShippingAddress : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int OrderId { get; set; }
        public required Order Order { get; set; }

    }
}
