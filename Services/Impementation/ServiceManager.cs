
using AutoMapper;
using Domain.Repository;
using Services.Abstract.Interfaces;
using System;

namespace Services.Impementation
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<ICategoryService> _categoryService;

        public ServiceManager(IUnitOfWork uow, IMapper mapper)
        {
            _productService = new Lazy<IProductService>(() => new ProductService(uow, mapper));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(uow, mapper));
        }

        public IProductService ProductService => _productService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
    }
}
