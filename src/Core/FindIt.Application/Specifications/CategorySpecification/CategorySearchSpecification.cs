using FindIt.Domain.ProductEntities;
using FindIt.Domain.Specifications;
using System;
using System.Linq;

namespace FindIt.Application.Specifications.CategorySpecification
{
    public class CategorySearchSpecification : BaseSpecifications<Category>
    {
        public CategorySearchSpecification(string searchQuery)
        {
            WhereCriteria=(c => c.Name != null &&c.Name.ToLower().Contains(searchQuery.ToLower()));
        }
    }
}
