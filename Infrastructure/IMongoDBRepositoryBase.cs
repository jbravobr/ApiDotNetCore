using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ApiDotNetCore.Infrastructure
{
    public interface IMongoDBRepositoryBase<T> where T : class
    {
        Task<T> GetMostRecent();

        Task<ICollection<T>> GetAll();

        Task<ICollection<T>> GetAllWithFilter(Expression<Func<T, bool>> expr);

        Task<T> GetById(ObjectId id);

        Task<T> GetWithFilter(Expression<Func<T, bool>> expr);

        void Insert(T TEntity);

        Task<bool> Update(ObjectId id, T TEntity);

        Task<bool> Delete(T TEntity);

        Task<bool> DeleteById(ObjectId id);
    }
}