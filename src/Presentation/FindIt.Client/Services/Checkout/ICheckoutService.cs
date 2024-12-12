using FindIt.Shared.Checkout;

namespace FindIt.Client.Services.Checkout;
public interface ICheckoutService
{
	Task<List<OrderDeliveryMethodModel>> GetDeliveryMethods();
}