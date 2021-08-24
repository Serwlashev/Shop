using AutoMapper;
using Domain.Repository;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Impementation
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

        public abstract void Create(TValue entity);
        public abstract Task<TValue> Get(TKey id);
        public abstract Task<IEnumerable<TValue>> GetAll();
        public abstract void Remove(TKey id);
        public abstract void Update(TValue entity);
    }
}
