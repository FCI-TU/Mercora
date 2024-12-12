using FindIt.Application.ErrorHandling;
using FindIt.Shared.Cart;

namespace FindIt.Application.Interfaces;
public interface ICartService
{
    Task<Result<CartResponse>> CreateOrUpdateCartAsync(CartRequest cartRequest);
    Task<Result<CartResponse>> GetCartAsync(string id);
    Task DeleteCartAsync(string id);
}