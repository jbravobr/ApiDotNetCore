using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ApiDotNetCore
{
    public interface IServiceBase<T> where T : class
    {
        Task<T> GetMostRecent();

        Task<ICollection<T>> GetAll();

        Task<ICollection<T>> GetAllWithFilter(Expression<Func<T, bool>> expr);

        Task<T> GetById(string id);

        Task<T> GetWithFilter(Expression<Func<T, bool>> expr);

        void Insert(T TEntity);

        Task<bool> Update(string id, T TEntity);

        Task<bool> Delete(T TEntity);

        Task<bool> DeleteById(string id);
    }
}