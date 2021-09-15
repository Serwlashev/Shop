using Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Domain.Interfaces.Repository
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
        Task<IEnumerable<TValue>> GetByConditionAsync(Expression<Func<TValue, bool>> predicate);
    }
}
