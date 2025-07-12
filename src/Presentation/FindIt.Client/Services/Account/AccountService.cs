﻿using FindIt.Shared.Checkout;
using System.Net.Http.Json;

namespace FindIt.Client.Services.Account;
public class AccountService(IHttpClientFactory _httpClientFactory) : IAccountService
{
	private readonly HttpClient httpClient = _httpClientFactory.CreateClient("Auth");

	public async Task<UserAddressModel?> GetUserAddressAsync()
	{
		try
		{
			var response = await httpClient.GetAsync("api/v1/account/get-current-user-address");

			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadFromJsonAsync<UserAddressModel>();
			}

			return null;
		}
		catch
		{
			return null;
		}
	}

	public async Task<UserAddressModel?> UpdateUserAddressAsync(UserAddressModel userAddressRequest)
	{
		try
		{
			var response = await httpClient.PutAsJsonAsync("api/v1/account/update-current-user-address", userAddressRequest);

			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadFromJsonAsync<UserAddressModel>();
			}

			return null;
		}
		catch
		{
			return null;
		}
	}

}