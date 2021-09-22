namespace Core.Application.Interfaces
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        IAccountsService AccountsService { get; }
        ICartService CartService { get; }
    }
}
