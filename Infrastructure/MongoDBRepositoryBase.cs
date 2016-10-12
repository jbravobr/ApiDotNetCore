using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiDotNetCore.Domain;
using ApiDotNetCore.Infrastructure;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiDotNetCore
{
    public class MongoDBRepositoryBase<T> : IMongoDBRepositoryBase<T> where T : EntityBase
    {
        IMongoDatabase _db;
        string typeName = "BsonDocument";

        public MongoDBRepositoryBase()
        {
            _db = MongoDBInstance.GetMongoDatabase;
        }

        public async Task<ICollection<T>> GetAll()
        {
            try
            {
                var ret = _db.GetCollection<T>(typeName).AsQueryable();
                return await ret.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetById(ObjectId id)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq(x => x._id, id);
                return await _db.GetCollection<T>(typeName).Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<T>> GetAllWithFilter(Expression<Func<T, bool>> expr)
        {
            try
            {
                var filter = Builders<T>.Filter.Where(expr);
                var collection = await _db.GetCollection<T>(typeName).FindAsync(filter);
                var retList = new List<T>();

                await collection.ForEachAsync((T Entity) =>
                {
                    retList.Add(Entity);
                });

                return retList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetWithFilter(Expression<Func<T, bool>> expr)
        {
            try
            {
                var filter = Builders<T>.Filter.Where(expr);
                var collection = await _db.GetCollection<T>(typeName).FindAsync(filter);

                return await collection.FirstOrDefaultAsync<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(T TEntity)
        {
            try
            {
                _db.GetCollection<T>(typeName).InsertOne(TEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(ObjectId id, T TEntity)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq(x => x._id, id);
                var result = await _db.GetCollection<T>(typeName).ReplaceOneAsync(filter
                                                                                    , TEntity
                                                                                    , new UpdateOptions { IsUpsert = true });

                return await Task.FromResult(result.ModifiedCount > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(T TEntity)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq(x => x._id, TEntity._id);
                var result = await _db.GetCollection<T>(typeName).DeleteOneAsync(filter);

                return await Task.FromResult(result.DeletedCount > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteById(ObjectId id)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq(x => x._id, id);
                var result = await _db.GetCollection<T>(typeName).FindOneAndDeleteAsync(filter);

                return await Task.FromResult(result != null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetMostRecent()
        {
            try
            {
                var sort = Builders<T>.Sort.Descending(x => x.CreationDate);
                var filter = new BsonDocument();
                var result = _db.GetCollection<T>(typeName).Find(filter);

                return await result.Sort(sort).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}