using Domain.Entity;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Implementation.Repositories
{
    public class ProductsRepository : BaseRepository<long, Product>
    {
        public ProductsRepository(ApplicationDbContext context) 
            : base(context)
        {
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
            => await _context.Products.Include(p => p.Category).ToListAsync();
    }
}
