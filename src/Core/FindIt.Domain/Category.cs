
using FindIt.Domain.Common;

namespace FindIt.Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
       // public virtual ICollection<Product> Products { get; set; } = null!;

    }
}
