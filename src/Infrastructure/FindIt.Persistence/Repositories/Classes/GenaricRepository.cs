using FindIt.Persistence.Interfaces;
using FindIt.Persistence.Specifications;
using FindIt.Shared;
using Microsoft.EntityFrameworkCore;

namespace FindIt.Persistence.Repositories.Classes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        #region Constractor
        private readonly StoreDbContext _dbContext;

        public GenericRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods
        public void Add(T entity) => _dbContext.Set<T>().Add(entity);

        public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> GetAllBySpecificationAsync(ISpecifications<T> specification)
        {
            var query = ApplySpecification(specification);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool withNoTracking = true)
        {
            var query = withNoTracking ? _dbContext.Set<T>().AsNoTracking() : _dbContext.Set<T>();
            return await query.ToListAsync();
        }


        public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);

        public void Update(T entity) => _dbContext.Set<T>().Update(entity);

        private IQueryable<T> ApplySpecification(ISpecifications<T> specification)
        {
            return SpecificationQueryEvaluator<T>.GetQuery(_dbContext.Set<T>(), specification);
        }
        #endregion
    }
}
