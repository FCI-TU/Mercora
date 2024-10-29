using FindIt.Shared.Authentications;
using System.Net.Http.Json;

namespace FindIt.Client.Services.Authentication;
public class AuthenticationService(HttpClient httpClient): IAuthenticationService
{
    public Task<AppUserResponse> RegisterAsync(RegisterRequest registerRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<AppUserResponse?> LoginAsync(LoginRequest loginRequest)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("api/auth/login", loginRequest);

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