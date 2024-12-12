using StackExchange.Redis;

namespace FindIt.Server.ServicesExtension;
public static class RedisConfigurationExtension
{
    public static IServiceCollection AddRedis(this IServiceCollection services, string redisConnection)
    {
        services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(redisConnection));

        return services;
    }
}