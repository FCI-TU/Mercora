using FindIt.Domain.CartEntities;

namespace FindIt.Domain.Interfaces;
public interface ICartRepository
{
    Task<Cart?> CreateOrUpdateCartAsync(Cart cart);
    Task<Cart?> GetCartAsync(string cartId);
    Task<bool> DeleteCartAsync(string cartId);
}