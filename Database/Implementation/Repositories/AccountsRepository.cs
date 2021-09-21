using Core.Domain.Entity;
using Core.Domain.Interfaces.Repository;

namespace Infrastructure.Persistence.Implementation.Repositories
{
    public class AccountsRepository : BaseRepository<long, User>, IAccountsRepository<long, User>
    {
        public AccountsRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
