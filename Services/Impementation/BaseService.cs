using Core.Application.Interfaces;
using AutoMapper;
using Core.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using System.Threading;

namespace Infrastructure.Services.Impementation
{
    public abstract class BaseService<TKey, TValue> : IBaseService<TKey, TValue>
    {
        protected IUnitOfWork _uow;
        protected IMapper _mapper;

        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public abstract Task<bool> CreateAsync(TValue entity, CancellationToken token = default);
        public abstract Task<TValue> GetAsync(TKey id, CancellationToken token = default);
        public abstract Task<IEnumerable<TValue>> GetAllAsync(CancellationToken token = default);
        public abstract Task<bool> RemoveAsync(TKey id, CancellationToken token = default);
        public abstract Task<bool> UpdateAsync(TValue entity, CancellationToken token = default);
        public abstract Task<IEnumerable<TValue>> GetByConditionAsync(Expression<Func<TValue, bool>> predicate, CancellationToken token = default);
    }
}
