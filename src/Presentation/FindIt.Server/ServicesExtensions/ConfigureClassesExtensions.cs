using FindIt.Application.Settings;

namespace FindIt.Server.ServicesExtensions
{
    public static class ConfigureClassesExtensions
    {
        public static IServiceCollection ConfigureAppSettingsData(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtData>(configuration.GetSection("JWT"));

            return services;
        }
    }
}
