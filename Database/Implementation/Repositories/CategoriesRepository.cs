using Core.Domain.Entity;

namespace Infrastructure.Persistence.Implementation.Repositories
{
    public class CategoriesRepository : BaseRepository<long, Category>
    {
        public CategoriesRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
