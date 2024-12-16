using FindIt.Application.Interfaces;
using FindIt.Application.Services;
using FindIt.Domain.Interfaces;
using FindIt.Domain.ProductEntities;
using FindIt.Persistence.Repositories;

namespace FindIt.Server.ServicesExtensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<IAuthService, AuthService>();
           
            #region Brand

            services.AddAutoMapper(typeof(BrandProfileMapExtension));

            services.AddScoped<IBrandService, BrandService>();

            #endregion

            #region Category
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(CategoryProfileMapExtension)); 
            #endregion

            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
