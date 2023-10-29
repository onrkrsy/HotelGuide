using Newtonsoft.Json;
using ServiceCore.Models.Abstract;
using ServiceCore.Repositories;
using System.Linq.Expressions;
namespace HotelService.Application.Services
{
    public class GenericBusiness<TEntity> : IGenericBusiness<TEntity> where TEntity : class, IEntity
    {
        private readonly IGenericRepository<TEntity> genericRepository;

        public GenericBusiness(IGenericRepository<TEntity> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public virtual async Task<TEntity> Add(TEntity model)
        {
            return await genericRepository.Create(model);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await genericRepository.GetAll();
        } 
        public virtual async Task<TEntity> Get(Guid id)
        {
            return await genericRepository.Get(id);
        }

        public virtual async Task<TEntity> Update(Guid id, string updateRequest)
        {
            var updateEntity = await genericRepository.Get(id);
            if (updateEntity == null) return null;
            JsonConvert.PopulateObject(updateRequest, updateEntity);
            updateEntity = await genericRepository.Update(updateEntity);

            return updateEntity;
        }
        public virtual async Task<TEntity> Update(TEntity entity)
        { 
            return  await genericRepository.Update(entity); 
        }

        public virtual async Task Delete(Guid id)
        {
            await genericRepository.Delete(id);
        }
        public IQueryable<TEntity> GetQuery(string includeProperties)
        {
            return genericRepository.GetQuery(includeProperties);
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter)
        {
            return genericRepository.GetQuery(filter);
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter, string includeProperties)
        {
            return genericRepository.GetQuery(filter, includeProperties);
        }

        public IQueryable<TEntity> GetQuery()
        {
            return genericRepository.GetQuery();
        }
    }
}
