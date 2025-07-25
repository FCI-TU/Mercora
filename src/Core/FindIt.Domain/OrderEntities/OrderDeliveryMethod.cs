﻿using FindIt.Domain.Common;

namespace FindIt.Domain.OrderEntities;
public class OrderDeliveryMethod : BaseEntity
{
	public OrderDeliveryMethod() { /* we create this constructor because EF need it while migration to make instance from this class */ }
	public OrderDeliveryMethod(string name, string description, decimal cost, string deliveryTime)
	{
		Name = name;
		Description = description;
		Cost = cost;
		DeliveryTime = deliveryTime;
	}

	public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Cost { get; set; }
    public string DeliveryTime { get; set; } = null!;
}