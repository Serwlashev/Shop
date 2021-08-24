using Domain.Entity;
using Infrastructure.Database;
using System;
using System.Threading.Tasks;

namespace Database.Implementation.Repositories
{
    public class ProductsRepository : BaseRepository<long, Product>
    {
        public ProductsRepository(ApplicationDbContext context) 
            : base(context)
        {
        }

        public override void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
