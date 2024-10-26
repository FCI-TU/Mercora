using FindIt.Application.ServiceExtensions;
using FindIt.Application.Settings;
using FindIt.Server.ServicesExtensions;
using Microsoft.Extensions.Options;

namespace FindIt.Server
{
    public static class DependencyInjection
    {
        public static WebApplicationBuilder AddApplicationDependencies(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var configuration = builder.Configuration;
            var environment = builder.Environment;

            services.ConfigureAppSettingsData(configuration);

            var servicesProvider = services.BuildServiceProvider();

            var jwtData = servicesProvider.GetRequiredService<IOptions<JwtData>>().Value;

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSwaggerServices();

            services.AddAuthenticationService(jwtData, configuration);


            return builder;
        }
    }
}
