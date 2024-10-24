using System.Linq.Expressions;

namespace FindIt.Persistence.Interfaces
{
    public interface ISpecifications<T> where T : class
    {
        Expression<Func<T, bool>> WhereCriteria { get; set; }
    }
}
