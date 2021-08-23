using Domain.Entity;
using Domain.Repository;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Implementation.Repositories
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
        public async Task<IEnumerable<TValue>> GetAll()
            => await Table.ToListAsync();

        public async Task<TValue> Get(TKey id)
            => await Table.FindAsync(id);

        public abstract Task Create(TValue entity);

        public async Task Remove(TKey id)
            => Table.Remove(await Get(id));

        public abstract Task Update(TValue entity);
    }
}
