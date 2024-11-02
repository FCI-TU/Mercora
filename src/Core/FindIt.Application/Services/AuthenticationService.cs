using FindIt.Application.ErrorHandling;
using FindIt.Application.Interfaces.Services;
using FindIt.Application.Settings;
using FindIt.Domain.IdentityEntities;
using FindIt.Shared.Authentications;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FindIt.Infrastructure.Services;

public class AuthenticationService(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, JwtData _jwtData, HttpClient _httpClient) : IAuthenticationService
{
	private async Task<string> GenerateAccessTokenAsync(AppUser user)
	{
		var authClaims = new List<Claim>
			{
				new (ClaimTypes.GivenName, user.UserName!),
				new (ClaimTypes.Email, user.Email!)
			};

		var userRoles = await _userManager.GetRolesAsync(user);
		authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

		// secretKey
		var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtData.SecretKey));

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Expires = DateTime.UtcNow.AddDays(_jwtData.DurationInDays),
			Claims = authClaims.ToDictionary(c => c.Type, c => (object)c.Value),
			Audience = _jwtData.ValidAudience,
			Issuer = _jwtData.ValidIssuer,
			SigningCredentials = new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature),
			// EncryptingCredentials = new EncryptingCredentials(TokenEncryption.RsaKey, SecurityAlgorithms.RsaOAEP, SecurityAlgorithms.Aes128CbcHmacSha256)
		};

		var tokenHandler = new JwtSecurityTokenHandler();
		var token = tokenHandler.CreateToken(tokenDescriptor);

		// Create token and return encrypted JWT (JWE) 
		return tokenHandler.WriteToken(token);
	}

	public async Task<Result<AppUserResponse>> CreateUserResponse(AppUser user)
	{
		var token = await GenerateAccessTokenAsync(user);
		var userRoles = await _userManager.GetRolesAsync(user);

		var userResponse = new AppUserResponse
		{
			FirstName = user.FirstName,
			LastName = user.LastName,
			Email = user.Email!,
			PhoneNumber = user.PhoneNumber!,
			Token = token,
			IsVerified = user.EmailConfirmed,
			Roles = userRoles,
		};

		return Result<AppUserResponse>.Success(userResponse);
	}

	public async Task<Result<AppUserResponse>> LoginUserAsync(LoginRequest login)
	{
		var user = await _userManager.FindByEmailAsync(login.Email);

		if (user is null || login.Password is null)
		{
			return Result<AppUserResponse>.Failure(new Status(StatusCode.NotFound, "No user registered with this email!"));
		}
		var result = await _signInManager.CheckPasswordSignInAsync(user!, login.Password, false);
		
		if (!result.Succeeded)
		{
			return Result<AppUserResponse>.Failure(new Status(StatusCode.Unauthorized, "Incorrect email or password!"));
		}

		return await CreateUserResponse(user);
	}
	public async Task<Result<AppUserResponse>> RegisterUserAsync(RegisterRequest register)
	{

		
		if (_userManager.FindByEmailAsync(register.Email).Result != null)
		{
			return Result<AppUserResponse>.Failure(new Status(StatusCode.Conflict, "A user with this email already exists!"));
		}
		var user = new AppUser { Email = register.Email, UserName = register.Email.Split('@')[0], FirstName = register.FirstName, LastName = register.LastName };
		var result = await _userManager.CreateAsync(user, register.Password);
		var userResponse = new AppUserResponse {
			FirstName = user.FirstName,
			LastName = user.LastName,
			Email = user.Email,
			PhoneNumber = user.PhoneNumber!,
			Token = await GenerateAccessTokenAsync(user),
			IsVerified = user.EmailConfirmed,
			Roles = await _userManager.GetRolesAsync(user)
		};

		return result.Succeeded ? Result<AppUserResponse>.Success(userResponse) : Result<AppUserResponse>.Failure(new Status(StatusCode.BadRequest));
	}
	public async void LogoutUserAsync()
	{
		await _signInManager.SignOutAsync();
	}
	public async Task<Result> DeleteUserAsync()
	{
		throw new NotImplementedException();
	}
	public async Task<AppUserResponse> GetUserAsync()
	{
		throw new NotImplementedException();
	}
}
