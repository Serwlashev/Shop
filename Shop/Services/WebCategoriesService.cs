using AutoMapper;
using Services.DTO;
using Services.Interfaces;
using Shop.Models;
using Shop.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class WebCategoriesService : IWebCategoriesService
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public WebCategoriesService(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public void Create(CategoryViewModel entity)
            => _serviceManager.CategoryService.Create(_mapper.Map<CategoryDTO>(entity));

        public async Task<CategoryViewModel> Get(long id)
            => _mapper.Map<CategoryViewModel>(await _serviceManager.CategoryService.Get(id));

        public async Task<IEnumerable<CategoryViewModel>> GetAll()
            => _mapper.Map<IEnumerable<CategoryViewModel>>(await _serviceManager.CategoryService.GetAll());

        public void Remove(long id)
            => _serviceManager.CategoryService.Remove(id);

        public void Update(CategoryViewModel entity)
            => _serviceManager.CategoryService.Update(_mapper.Map<CategoryDTO>(entity));
    }
}
