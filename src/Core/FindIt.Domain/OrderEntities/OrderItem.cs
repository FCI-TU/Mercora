using FindIt.Domain.Common;

namespace FindIt.Domain.OrderEntities;
public class OrderItem : BaseEntity
{
    public ProductOrderItem Product { get; set; } = null!;
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}