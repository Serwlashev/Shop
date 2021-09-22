using Core.Domain.Entity;
using Core.Domain.Interfaces.Repository;

namespace Infrastructure.Persistence.Implementation.Repositories
{
    public class CartRepository : BaseRepository<long, CartItem>, ICartRepository<long, CartItem> 
    {
        public CartRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
