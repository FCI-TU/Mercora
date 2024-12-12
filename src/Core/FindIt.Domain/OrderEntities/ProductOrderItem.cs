namespace FindIt.Domain.OrderEntities;
public class ProductOrderItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public string ProductImageCover { get; set; } = null!;
}
