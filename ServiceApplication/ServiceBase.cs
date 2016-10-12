using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiDotNetCore.Infrastructure;
using MongoDB.Bson;

namespace ApiDotNetCore
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        readonly IMongoDBRepositoryBase<T> _mongoRepo;

        public ServiceBase(IMongoDBRepositoryBase<T> mongoRepo)
        {
            _mongoRepo = mongoRepo;
        }

        public async Task<bool> Delete(T TEntity)
        {
            return await _mongoRepo.Delete(TEntity);
        }

        public async Task<bool> DeleteById(string id)
        {
            var _id = ObjectId.Parse(id.ToString());
            return await _mongoRepo.DeleteById(_id);
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _mongoRepo.GetAll();
        }

        public async Task<ICollection<T>> GetAllWithFilter(Expression<Func<T, bool>> expr)
        {
            return await _mongoRepo.GetAllWithFilter(expr);
        }

        public async Task<T> GetById(string id)
        {
            var _id = ObjectId.Parse(id.ToString());
            return await _mongoRepo.GetById(_id);
        }

        public async Task<T> GetMostRecent()
        {
            return await _mongoRepo.GetMostRecent();
        }

        public async Task<T> GetWithFilter(Expression<Func<T, bool>> expr)
        {
            return await _mongoRepo.GetWithFilter(expr);
        }

        public void Insert(T TEntity)
        {
            _mongoRepo.Insert(TEntity);
        }

        public async Task<bool> Update(string id, T TEntity)
        {
            var _id = ObjectId.Parse(id.ToString());
            return await _mongoRepo.Update(_id, TEntity);
        }
    }
}