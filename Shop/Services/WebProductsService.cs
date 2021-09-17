using AutoMapper;
using Presentation.Shop.Models;
using Presentation.Shop.Services.Interfaces;
using Presentation.Shop.Utils.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Shop.Services
{
    public class WebProductsService : IWebProductsService
    {
        private readonly IApiUtil _apiUtil;

        public WebProductsService(IApiUtil apiUtil)
        {
            _apiUtil = apiUtil;
        }

        public async Task<bool> CreateAsync(ProductModel entity)
            => await _apiUtil.PostAsync("api/products", entity);

        public async Task<ProductModel> GetAsync(long id)
            => await _apiUtil.GetAsync<ProductModel>($"api/products/{id}");

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
            => await _apiUtil.GetAsync<IEnumerable<ProductModel>>("api/products");

        public async Task<bool> RemoveAsync(long id)
            => await _apiUtil.DeleteAsync($"api/products/{id}");

        public async Task<bool> UpdateAsync(ProductModel entity)
            => await _apiUtil.PostAsync("api/products", entity);
    }
}
