using FindIt.Domain.Common;
using FindIt.Persistence.Interfaces;
using FindIt.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindIt.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreDbContext _dbContext;

        public GenericRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(bool withNoTracking = true)
        {
            var query = withNoTracking ? _dbContext.Set<T>().AsNoTracking() : _dbContext.Set<T>();
            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByCriteriaAsync(ISpecifications<T> specification)
        {
            var query = ApplySpecification(specification);
            return await query.FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllBySpecificationAsync(ISpecifications<T> specification)
        {
            var query = ApplySpecification(specification);
            return await query.ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecifications<T> specification)
        {
            return SpecificationQueryEvaluator<T>.GetQuery(_dbContext.Set<T>(), specification);
        }
    }
}
