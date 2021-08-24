using Database.Implementation.Repositories;
using Domain.Entity;
using Domain.Repository;
using Infrastructure.Database;
using System.Threading.Tasks;

namespace Database.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        private IRepository<long, Category> _categoriesRepository;
        private IRepository<long, Product> _productsRepository;

        public IRepository<long, Product> ProductsRepository
            => _productsRepository ??= new ProductsRepository(db);
        public IRepository<long, Category> CategoriesRepository
            => _categoriesRepository ??= new CategoriesRepository(db);

        public UnitOfWork(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task SaveChangesAsync()
            => await db.SaveChangesAsync();
    }
}
