using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IBaseService<TKey, TValue>
    {
        Task<IEnumerable<TValue>> GetAllAsync(CancellationToken token = default);
        Task<TValue> GetAsync(TKey id, CancellationToken token = default);
        Task<bool> UpdateAsync(TValue entity, CancellationToken token = default);
        Task<bool> CreateAsync(TValue entity, CancellationToken token = default);
        Task<bool> RemoveAsync(TKey id, CancellationToken token = default);
        Task<IEnumerable<TValue>> GetByConditionAsync(Expression<Func<TValue, bool>> predicate, CancellationToken token = default);
    }
}
