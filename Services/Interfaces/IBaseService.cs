using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBaseService<TKey, TValue>
    {
        Task<IEnumerable<TValue>> GetAll();
        Task<TValue> Get(TKey id);
        void Update(TValue entity);
        void Create(TValue entity);
        void Remove(TKey id);
    }
}
