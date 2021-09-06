using Core.Domain.Entity;
using Core.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Implementation.Repositories
{
    public abstract class BaseRepository<TKey, TValue> : IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        protected readonly ApplicationDbContext _context;
        protected DbSet<TValue> Table => _context.Set<TValue>();

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<TValue>> GetAllAsync()
            => await Table.ToListAsync();

        public async Task<TValue> GetAsync(TKey id)
            => await Table.FindAsync(id);

        public void Create(TValue entity)
            => Table.Add(entity);

        public void Remove(TValue entity)
            => Table.Remove(entity);

        public void Update(TValue entity)
            => Table.Update(entity);
    }
}
