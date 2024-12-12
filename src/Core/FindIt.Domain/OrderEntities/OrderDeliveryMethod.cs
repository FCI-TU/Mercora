using FindIt.Domain.Common;

namespace FindIt.Domain.OrderEntities;
public class OrderDeliveryMethod : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Cost { get; set; }
    public string DeliveryTime { get; set; } = null!;
}