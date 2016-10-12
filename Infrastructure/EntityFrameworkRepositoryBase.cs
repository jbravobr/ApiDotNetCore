using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDotNetCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace ApiDotNetCore.Infrastructure
{
    public class EntityFrameworkRepositoryBase<T> : IEntityRepositoryBase<T> where T : EntityBase, new()
    {
        public DatabaseContext DBContext = new DatabaseContext();

        public async Task<ICollection<T>> GetAll()
        {
            try
            {
                return await DBContext.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}