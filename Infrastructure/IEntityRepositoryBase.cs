using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotNetCore.Infrastructure
{
    public interface IEntityRepositoryBase<T> where T : class
    {
        Task<ICollection<T>> GetAll();

        Task<T> GetById(int id);
    }
}