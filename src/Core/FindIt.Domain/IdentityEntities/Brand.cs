using FindIt.Domain.Common;


namespace FindIt.Domain.IdentityEntities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? LogUrl { get; set; }
    }
}
