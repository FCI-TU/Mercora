using FindIt.Domain.Common;


namespace FindIt.Domain.IdentityEntities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? Percentage { get; set; }
        public int StockQuantity { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public string? Status { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }


        // Navigation properties for relationships
        public ICollection<ProductColor> ProductColors { get; set; } = null!;
        //public ICollection<ProductSize> ProductSizes { get; set; }
    }
}
