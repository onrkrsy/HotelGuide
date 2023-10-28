using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Infrastructure.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
        IQueryable<T> GetQuery();
        IQueryable<T> GetQuery(string includeProperties);
        IQueryable<T> GetQuery(Expression<Func<T, bool>> filter);
        IQueryable<T> GetQuery(Expression<Func<T, bool>> filter, string includeProperties);
        IQueryable<T> GetQuery(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        IQueryable<T> GetQuery(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties);
    }
}
