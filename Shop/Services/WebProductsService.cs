using AutoMapper;
using Services.DTO;
using Services.Interfaces;
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

        public void Create(ProductViewModel entity)
            => _serviceManager.ProductService.Create(_mapper.Map<ProductDTO>(entity));

        public async Task<ProductViewModel> Get(long id)
            => _mapper.Map<ProductViewModel>(await _serviceManager.ProductService.Get(id));

        public async Task<IEnumerable<ProductViewModel>> GetAll()
            => _mapper.Map<IEnumerable<ProductViewModel>>(await _serviceManager.ProductService.GetAll());

        public void Remove(long id)
            => _serviceManager.ProductService.Remove(id);

        public void Update(ProductViewModel entity)
            => _serviceManager.ProductService.Update(_mapper.Map<ProductDTO>(entity));
    }
}
