using Core.Domain.Entity;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Implementation.Repositories
{
    public class ProductsRepository : BaseRepository<long, Product>
    {
        public ProductsRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            var entities = await _context.Products.Include(p => p.Category).ToListAsync();

            if (!entities.Any())
            {
                throw new NotFoundException("Not found");
            }

            return entities;
        }

        public override async Task<Product> GetAsync(long id)
        {
            var entity = await _context.Products.Include(p => p.Category).FirstAsync(p => p.Id == id);

            if (entity == null)
            {
                throw new NotFoundException("Entity not found");
            }

            return entity;
        }
    }
}
