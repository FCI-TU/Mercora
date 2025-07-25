﻿using FindIt.Shared.Cart;
using FindIt.Shared.Checkout;
using FindIt.Shared.DTOs;

namespace FindIt.Client.Services.CartService;
public interface ICartService
{
	public event Action OnChange;

	public CartResponse? Cart { get; set; }

	public string Message { get; set; }

	Task InitializeCart();

	Task AddProductToCart(ProductResponse product, decimal quantity);

	Task IncreaseItemCountInCart(CartItemResponse item, decimal quantity);

	Task RemoveItemFromCart(int productId, decimal quantity);

	Task ChangeDeliveryMethod(OrderDeliveryMethodModel deliveryMethodModel);

	Task CreatePaymentIntend(string cartId);

	Task<string> PlaceOrder(string cartId);
}