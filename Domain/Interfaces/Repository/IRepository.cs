using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        Task<IEnumerable<TValue>> GetAllAsync();
        Task<TValue> GetAsync(TKey id);
        void Create(TValue entity);
        void Remove(TValue entity);
        void Update(TValue entity);
    }
}
