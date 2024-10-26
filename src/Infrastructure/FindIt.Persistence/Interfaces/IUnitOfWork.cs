using FindIt.Domain.Common;

namespace FindIt.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : BaseEntity;
        Task<int> CompleteAsync();
    }
}