using Core.Domain.Entity;
using Core.Domain.Interfaces.Repository;
using Domain.Exceptions;
using System.Linq;

namespace Infrastructure.Persistence.Implementation.Repositories
{
    public class CategoriesRepository : BaseRepository<long, Category>, ICategoriesRepository<long, Category>
    {
        public CategoriesRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override void Remove(Category entity)
        {
            if(_context.Products.Any(product => product.Id == entity.Id))
            {
                throw new ForbiddenActionException("Unable to delete category due to existing relationship with products!");
            }

            base.Remove(entity);
        }
    }
}
