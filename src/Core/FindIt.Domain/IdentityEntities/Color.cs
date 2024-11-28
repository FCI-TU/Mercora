using FindIt.Domain.Common;
namespace FindIt.Domain.IdentityEntities
{
    public class Color : BaseEntity
    {
        public string HexCode { get; set; } = null!;
        public string Name { get; set; } = null!;
        public virtual ProductColor ProductColor { get; set; } = null!;
    }
}