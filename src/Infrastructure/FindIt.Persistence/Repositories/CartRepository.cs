using System.Text.Json;
using FindIt.Domain.CartEntities;
using FindIt.Domain.Interfaces;
using StackExchange.Redis;

namespace FindIt.Persistence.Repositories;
public class CartRepository(IConnectionMultiplexer connection) : ICartRepository
{
    private readonly IDatabase _database = connection.GetDatabase();

    public async Task<Cart?> CreateOrUpdateCartAsync(Cart cart)
    {
        var createdOrUpdated = await _database.StringSetAsync(cart.Id, JsonSerializer.Serialize(cart), TimeSpan.FromDays(30));

        if (createdOrUpdated is false) return null;

        return await GetCartAsync(cart.Id);
    }
    public async Task<bool> DeleteCartAsync(string cartId)
    {
        return await _database.KeyDeleteAsync(cartId);
    }
    public async Task<Cart?> GetCartAsync(string cartId)
    {
        var cart = await _database.StringGetAsync(cartId);

        return cart.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Cart>(cart!);
    }
}