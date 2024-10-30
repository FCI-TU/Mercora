using FindIt.Shared.Authentications;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FindIt.Client.Services.Authentication;
public class AuthenticationService(HttpClient http, NavigationManager navigationManager) : IAuthenticationService
{
	public async Task<AppUserResponse?> RegisterAsync(RegisterRequest registerRequest)
	{
		var response = await http.PostAsJsonAsync("api/auth/register", registerRequest);

		if (!response.IsSuccessStatusCode)
		{
			// TODO: Implement api error handling
		}

		var userResponse = await response.Content.ReadFromJsonAsync<AppUserResponse>();
		return userResponse;
	}

	public async Task<AppUserResponse?> LoginAsync(LoginRequest loginRequest)
	{
		try
		{
			var response = await http.PostAsJsonAsync("api/auth/login", loginRequest);

			if (response.IsSuccessStatusCode)
			{
				var userResponse = await response.Content.ReadFromJsonAsync<AppUserResponse>();
				return userResponse;
			}
			else
			{
				return null;
			}
		}
		catch (Exception)
		{
			return null;
		}
	}
}