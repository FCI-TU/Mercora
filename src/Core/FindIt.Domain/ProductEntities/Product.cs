using FindIt.Domain.Common;

namespace FindIt.Domain.ProductEntities;
public class Product : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string ImageCover { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal RatingsAverage { get; set; }

    public bool Featured { get; set; }

    //[ForeignKey(nameof(Product.Brand))]  // With this data annotation we can solve problem (But We Don't Name ProductBrandId So EF Don't Know This FK) but we solve it with Fluent API
    public int BrandId { get; set; } // FK - ProductBrand - But We Don't Name ProductBrandId So EF Don't Know This FK So We Make It In Fluent API

    //[InverseProperty(nameof(ProductBrand.Products))] We use this data annotation to link with navigation property in product class (but we use it if exist many navigation properties)
    public Brand Brand { get; set; } = null!; // Navigational Property

    //[ForeignKey(nameof(Product.Category))]  // With this data annotation we can solve problem (But We Don't Name ProductCategoryId So EF Don't Know This FK) but we solve it with Fluent API
    public int CategoryId { get; set; } // FK - ProductCategory - But We Don't Name ProductCategoryId So EF Don't Know This FK So We Make It In Fluent API

    //[InverseProperty(nameof(ProductBrand.Products))] We use this data annotation to link with navigation property in product class (but we use it if exist many navigation properties)
    public Category Category { get; set; } = null!; // Navigational Property
}