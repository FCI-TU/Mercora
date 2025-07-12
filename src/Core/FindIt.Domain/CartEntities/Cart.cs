namespace FindIt.Domain.CartEntities;
public class Cart(string id)
{
	public string Id { get; set; } = id;
	public string UserEmail { get; set; } = string.Empty;
	public List<CartItem> Items { get; set; } = [];
	public int? DeliveryMethodId { get; set; }
	public decimal? ShippingPrice { get; set; }
	public string? PaymentIntentId { get; set; }
	public string? ClientSecret { get; set; }
}