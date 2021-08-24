using System.Collections.Generic;

namespace Shop.Services.Interfaces
{
    public interface IWebService<TKey, TValue>
    {
        IEnumerable<TValue> GetAll();
        TValue Get(TKey id);
        void Update(TValue entity);
        void Create(TValue entity);
        void Remove(TKey id);
    }
}
