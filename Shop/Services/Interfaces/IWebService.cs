using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Services.Interfaces
{
    public interface IWebService<TKey, TValue>
    {
        Task<IEnumerable<TValue>> GetAll();
        Task<TValue> Get(TKey id);
        void Update(TValue entity);
        void Create(TValue entity);
        void Remove(TKey id);
    }
}
