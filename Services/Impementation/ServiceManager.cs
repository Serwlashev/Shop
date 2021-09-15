using Core.Application.Interfaces;
using AutoMapper;
using Core.Domain.Interfaces.Repository;
using System;

namespace Infrastructure.Services.Impementation
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IAccountsService> _accountsService;

        public ServiceManager(IUnitOfWork uow, IMapper mapper)
        {
            _productService = new Lazy<IProductService>(() => new ProductService(uow, mapper));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(uow, mapper));
            _accountsService = new Lazy<IAccountsService>(() => new AccountsService(uow, mapper));
        }

        public IProductService ProductService => _productService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public IAccountsService AccountsService => _accountsService.Value;
    }
}
