using Core.Domain.Entity;

namespace Core.Domain.Interfaces.Repository
{
    public interface IAccountsRepository<TKey, TValue> : IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
    }
}
