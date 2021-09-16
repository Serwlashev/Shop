using AutoMapper;
using Presentation.Shop.Models;
using Presentation.Shop.Services.Interfaces;
using Presentation.Shop.Utils.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Shop.Services
{
    public class WebCategoriesService : IWebCategoriesService
    {
        private readonly IApiUtil _apiUtil;

        public WebCategoriesService(IApiUtil apiUtil)
        {
            _apiUtil = apiUtil;
        }

        public async Task<bool> CreateAsync(CategoryModel entity)
            => await _apiUtil.PostAsync("", entity);

        public async Task<CategoryModel> GetAsync(long id)
            => await _apiUtil.GetAsync<CategoryModel>($"/{id}");

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
            => await _apiUtil.GetAsync<IEnumerable<CategoryModel>>("");

        public async Task<bool> RemoveAsync(long id)
            => await _apiUtil.DeleteAsync($"/{id}");

        public async Task<bool> UpdateAsync(CategoryModel entity)
            => await _apiUtil.PostAsync("", entity);
    }
}
