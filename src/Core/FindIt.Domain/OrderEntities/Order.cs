using FindIt.Domain.Common;

namespace FindIt.Domain.OrderEntities;
public class Order : BaseEntity
{
	public Order() { /* we create this constructor because EF need it while migration to make instance from this class */ }

	public string BuyerEmail { get; set; } = null!;

	public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
	
	public OrderStatus Status { get; set; } = OrderStatus.Pending;
	#region Explaination
	// In this property
	// we need store in database string not number
	// so we create configuration for it
	#endregion

	public OrderAddress ShippingAddress { get; set; } = null!;
	#region Explaination
	// this is a navigation property
	// so EF will map it to database, but we don't need that
	// we need take his properties and mapped it in Order table
	// so will make configuration for that :)
	#endregion

	public decimal SubTotal { get; set; } // all salaries of items

	public string PaymentIntentId { get; set; } = null!;
    public OrderDeliveryMethod DeliveryMethod { get; set; } = null!;

    public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();

    public decimal GetTotal() => SubTotal + DeliveryMethod.Cost;
}