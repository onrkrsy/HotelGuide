using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Application.Services
{
    public interface IGenericBusiness<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity model);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(Guid id);
        Task<TEntity> Update(Guid id, string values);
        Task<TEntity> Update(TEntity entity);
        Task Delete(Guid id);
        IQueryable<TEntity> GetQuery();
        IQueryable<TEntity> GetQuery(string includeProperties);
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter, string includeProperties);
    }
}
