using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        Task<IEnumerable<TValue>> GetAll();
        Task<TValue> Get(TKey id);
        Task Create(TValue entity);
        Task Remove(TKey id);
        Task Update(TValue entity);
    }
}
