namespace Services.Abstract.Interfaces
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
    }
}
