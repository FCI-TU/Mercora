using FindIt.Shared.Authentications;

namespace FindIt.Client.Services.Authentication;
public class AuthenticationService(HttpClient httpClient): IAuthenticationService
{
    public Task<AppUserResponse> RegisterAsync(RegisterRequest registerRequest)
    {
        throw new NotImplementedException();
    }

    public Task<AppUserResponse> LoginAsync(LoginRequest loginRequest)
    {
        throw new NotImplementedException();
    }
}