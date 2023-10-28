using HotelService.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Infrastructure.Repositories.Concrete
{
    public class GenericRepository <TEntity> : IGenericRepository<TEntity>
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

        public virtual async Task<TEntity> Get(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            var x = _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Delete(Guid id)
        {
            TEntity entity = null;
            try
            {
                entity = await _dbContext.Set<TEntity>().FindAsync(id);
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                var result = ex.Message;
            }

            return entity;
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
