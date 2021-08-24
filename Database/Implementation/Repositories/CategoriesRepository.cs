using Domain.Entity;
using Infrastructure.Database;
using System;
using System.Threading.Tasks;

namespace Database.Implementation.Repositories
{
    public class CategoriesRepository : BaseRepository<long, Category>
    {
        public CategoriesRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override void Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
