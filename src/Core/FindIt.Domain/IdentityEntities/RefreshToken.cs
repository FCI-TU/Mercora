using FindIt.Domain.Common;

namespace FindIt.Domain.IdentityEntities
{
    public class RefreshToken : BaseEntity
    {


        public string Token { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiredAt { get; set; }

        public DateTime? RevokedAt { get; set; }

        public int UserId { get; set; }

        public virtual AppUser AppUser { get; set; } = null!;

    }
}
