
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FindIt.Domain.Common;

namespace FindIt.Domain.IdentityEntities
{
    public class IdentityCode : BaseEntity
    {



        public string Code { get; set; } = null!;

        public bool IsActive { get; set; }

        public bool ForRegistrationConfirmation { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime? ActivationTime { get; set; }

        public int UserId { get; set; }

        public virtual AppUser AppUser { get; set; } = null!;
    }
}


