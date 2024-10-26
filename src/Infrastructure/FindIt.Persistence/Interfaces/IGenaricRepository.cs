using FindIt.Domain.Common;
using FindIt.Shared;
namespace FindIt.Persistence.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(bool WithNoTaraKing = true);
        Task<T> GetByIdAsync(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> GetAllBySpecificationAsync(ISpecifications<T> specification);


    }
}
