using Core.Domain.Entity;
using Core.Domain.Interfaces.Repository;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Implementation.Repositories
{
    public class ProductsRepository : BaseRepository<long, Product>, IProductsRepository<long, Product>
    {
        public ProductsRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Product>> FindProductsAsync(string searchText)
        {
            IEnumerable<Product> entities = null;

            if(string.IsNullOrEmpty(searchText))
            {
                entities = await _context.Products.Include(p => p.Category).ToListAsync();
            }
            else
            {
                entities = await _context.Products.Include(p => p.Category).Where(product => product.Name.ToLower().Equals(searchText.ToLower()) || product.Category.Name.ToLower().Equals(searchText.ToLower())).ToListAsync();
            }

            if (!entities.Any())
            {
                throw new NotFoundException("Not found");
            }

            return entities;
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
