using FindIt.Domain.Common;

namespace FindIt.Domain.IdentityEntities
{
    public class ProductColor
    {
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
