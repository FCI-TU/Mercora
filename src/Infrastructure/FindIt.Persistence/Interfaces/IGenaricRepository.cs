using FindIt.Domain.Common;

namespace FindIt.Persistence.Interfaces;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync(bool withNoTracking = true);
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByCriteriaAsync(ISpecifications<T> specification);
    Task AddAsync(T entity); 
    void Update(T entity);
    void Delete(T entity);
    Task<IEnumerable<T>> GetAllBySpecificationAsync(ISpecifications<T> specification);
}