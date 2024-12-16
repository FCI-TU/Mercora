using AutoMapper;
using FindIt.Domain.ProductEntities;
using FindIt.Shared.DTOs;

namespace FindIt.Server.ServicesExtensions
{
    public class CategoryProfileMapExtension:Profile
    {
        public CategoryProfileMapExtension()
        {
            CreateMap<CategoryRequest, Category>();
            CreateMap<CategoryResponse, Category>();
        }
    }
}
