using FindIt.Domain.Common;
using FindIt.Persistence.Interfaces;

namespace FindIt.Persistence.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Constractor
        private readonly StoreDbContext _dbContext;
        private readonly Dictionary<string, object> _repositories = new();

        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion
        #region Methods
        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            var type = typeof(T).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryInstance = new GenericRepository<T>(_dbContext);
                _repositories[type] = repositoryInstance;
            }
            return (IGenericRepository<T>)_repositories[type];
        }

        public async Task<int> CompleteAsync() => await _dbContext.SaveChangesAsync();

        public void Dispose() => _dbContext.Dispose(); 
        #endregion
    }
}







