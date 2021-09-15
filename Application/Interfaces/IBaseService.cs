using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IBaseService<TKey, TValue>
    {
        Task<IEnumerable<TValue>> GetAllAsync();
        Task<TValue> GetAsync(TKey id);
        Task<bool> UpdateAsync(TValue entity);
        Task<bool> CreateAsync(TValue entity);
        Task<bool> RemoveAsync(TKey id);
        Task<IEnumerable<TValue>> GetByConditionAsync(Expression<Func<TValue, bool>> predicate);
    }
}
