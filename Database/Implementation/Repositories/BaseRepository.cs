using Core.Domain.Entity;
using Core.Domain.Interfaces.Repository;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
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

        public virtual async Task<IEnumerable<TValue>> GetAllAsync(CancellationToken token = default)
        {
            var entities = await Table.ToListAsync(token).ConfigureAwait(false);

            if(!entities.Any())
            {
                throw new NotFoundException("Not found");
            }

            return entities;
        }

        public virtual async Task<TValue> GetAsync(TKey id, CancellationToken token = default)
        {
            var entity = await Table.FindAsync(id, token).ConfigureAwait(false);

            if(entity == null)
            {
                throw new NotFoundException("Entity not found");
            }

            return entity;
        }

        public void Create(TValue entity)
            => Table.Add(entity);

        public virtual void Remove(TValue entity)
        {
            if(!Table.Contains(entity))
            {
                throw new NotFoundException("Cannot remove entity because it does not exist");
            }

            Table.Remove(entity);
        }

        public void Update(TValue entity)
        {
            if (!Table.Contains(entity))
            {
                throw new NotFoundException("Cannot update entity because it does not exist");
            }

            Table.Update(entity);
        }

        public async Task<IEnumerable<TValue>> GetByConditionAsync(Expression<Func<TValue, bool>> predicate, CancellationToken token = default)
        {
            return await Table.Where(predicate).AsQueryable().ToListAsync(token);
        }
    }
}
