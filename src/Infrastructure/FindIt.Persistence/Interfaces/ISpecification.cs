
using System.Linq.Expressions;

namespace FindIt.Persistence.Interfaces
{
    public interface ISpecification<T> where T : class
    {
        Expression<Func<T, bool>> WhereCriteria { get; set; }
        List<Expression<Func<T, object>>> InlcudesCriteria { get; set; }
        Expression<Func<T, object>> OrderBy { get; set; }
        Expression<Func<T, object>> OrderByDesc { get; set; }
        

        int Skip { get; set; }
        int Take { get; set; }

        bool IsPaginationEnabled { get; set; }

    }
}
