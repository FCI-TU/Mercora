using FindIt.Application.ErrorHandling;
using FindIt.Domain.IdentityEntities;
using FindIt.Shared.Authentications;

namespace FindIt.Application.Interfaces.Services;

public interface IAuthenticationService
{
	Task<AppUserResponse> GetUserAsync(string userId);
	Task<Result<AppUserResponse>> RegisterUserAsync(RegisterRequest register);
	Task<Result<AppUserResponse>> LoginUserAsync(LoginRequest register);
	Task<Result<AppUserResponse>> UpdateUserAsync(AppUser updatedUser);
	Task<Result> DeleteUserAsync(string userId);
}
