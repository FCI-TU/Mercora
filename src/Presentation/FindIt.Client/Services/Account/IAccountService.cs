using FindIt.Shared.Checkout;

namespace FindIt.Client.Services.Account;
public interface IAccountService
{
	Task<UserAddressModel?> GetUserAddressAsync();
	Task<UserAddressModel?> UpdateUserAddressAsync(UserAddressModel userAddressRequest);
}