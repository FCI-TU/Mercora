namespace FindIt.Domain.IdentityEntities;
public class CartItem{
    public int Id { get; set; } = null!;
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductImage { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total { get; set; }
    public int CartId { get; set; }
}