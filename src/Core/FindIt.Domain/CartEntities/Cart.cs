using FindIt.Domain.Common;
using FindIt.Domain.IdentityEntities;

namespace FindIt.Domain.CartEntities
{
    public class Cart : BaseEntity
    {
        public string UserId { get; set; } = null!;

        // Navigation property to the AppUser entity
        public virtual AppUser AppUser { get; set; } = null!;

        // Navigation property to the related CartItems
        //public virtual ICollection<CartItem> CartItems { get; set; } = null!;
    }
}
