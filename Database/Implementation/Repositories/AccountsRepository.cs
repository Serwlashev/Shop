using Core.Domain.Entity;

namespace Infrastructure.Persistence.Implementation.Repositories
{
    public class AccountsRepository : BaseRepository<long, User>
    {
        public AccountsRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
