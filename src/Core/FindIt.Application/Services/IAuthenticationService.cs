using FindIt.Application.ErrorHandling;
using FindIt.Domain.IdentityEntities;
using FindIt.Shared.Authentications;

namespace FindIt.Application.Interfaces.Services;

public interface IAuthenticationService
{
	Task<Result<AppUserResponse>> RegisterUserAsync(RegisterRequest register);
	Task<Result<AppUserResponse>> LoginUserAsync(LoginRequest register);
	void LogoutUserAsync();
	Task<AppUserResponse> GetUserAsync();
	Task<Result> DeleteUserAsync();
}
