using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FindIt.Domain.IdentityEntities
{
    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public virtual ICollection<UserAddress> UserAddresses { get; set; } = null!;
        //public virtual ICollection<IdentityCode> IdentityCodes { get; set; } = null!;
        //public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = null!;


    }
}