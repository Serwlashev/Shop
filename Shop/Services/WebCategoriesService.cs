using AutoMapper;
using Services.Abstract.DTO;
using Services.Abstract.Interfaces;
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

        public async Task<bool> CreateAsync(CategoryModel entity)
            => await _serviceManager.CategoryService.CreateAsync(_mapper.Map<CategoryDTO>(entity));

        public async Task<CategoryModel> GetAsync(long id)
            => _mapper.Map<CategoryModel>(await _serviceManager.CategoryService.GetAsync(id));

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
            => _mapper.Map<IEnumerable<CategoryModel>>(await _serviceManager.CategoryService.GetAllAsync());

        public Task<bool> RemoveAsync(long id)
            => _serviceManager.CategoryService.RemoveAsync(id);

        public Task<bool> UpdateAsync(CategoryModel entity)
            => _serviceManager.CategoryService.UpdateAsync(_mapper.Map<CategoryDTO>(entity));
    }
}
