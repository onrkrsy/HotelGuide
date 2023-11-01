using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public  async Task<TEntity> Get(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public  async Task<TEntity> Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity); 
            await _dbContext.SaveChangesAsync();  
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
             
            _dbContext.Set<TEntity>().Update(entity); 
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> Delete(Guid id)
        { 
            TEntity entity = await _dbContext.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;  // İşlem başarılıysa true döner.
            }
            return false;  
        }

        public virtual IQueryable<TEntity> GetQuery()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetQuery(string includeProperties)
        {
            return _dbContext.Set<TEntity>().Include(includeProperties);
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter)
        {
            return _dbContext.Set<TEntity>().Where(filter).AsQueryable();
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter, string includeProperties)
        {
            return _dbContext.Set<TEntity>().Where(filter).Include(includeProperties);
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            return orderBy(_dbContext.Set<TEntity>().Where(filter));
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties)
        {
            return orderBy(_dbContext.Set<TEntity>().Where(filter).Include(includeProperties));
        }
    }
}
