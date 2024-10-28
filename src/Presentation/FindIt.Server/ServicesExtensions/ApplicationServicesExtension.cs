using FindIt.Persistence.Interfaces;
using FindIt.Persistence.Repositories.Classes;

namespace FindIt.Server.ServicesExtensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
