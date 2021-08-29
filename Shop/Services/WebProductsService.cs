using AutoMapper;
using Services.Abstract.DTO;
using Services.Abstract.Interfaces;
using Shop.Models;
using Shop.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class WebProductsService : IWebProductsService
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public WebProductsService(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(ProductModel entity)
            => await _serviceManager.ProductService.CreateAsync(_mapper.Map<ProductDTO>(entity));

        public async Task<ProductModel> GetAsync(long id)
            => _mapper.Map<ProductModel>(await _serviceManager.ProductService.GetAsync(id));

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
            => _mapper.Map<IEnumerable<ProductModel>>(await _serviceManager.ProductService.GetAllAsync());

        public Task<bool> RemoveAsync(long id)
            => _serviceManager.ProductService.RemoveAsync(id);

        public Task<bool> UpdateAsync(ProductModel entity)
            => _serviceManager.ProductService.UpdateAsync(_mapper.Map<ProductDTO>(entity));
    }
}
