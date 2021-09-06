using AutoMapper;
using Core.Application.Interfaces;
using Core.Application.DTO;
using Core.Domain.Interfaces.Repository;
using Core.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.Impementation
{
    public class CategoryService : BaseService<long, CategoryDTO>, ICategoryService
    {
        public CategoryService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public async override Task<bool> CreateAsync(CategoryDTO entity)
        {
            _uow.CategoriesRepository.Create(_mapper.Map<Category>(entity));
            await _uow.SaveChangesAsync();
            
            return true;
        }

        public async override Task<CategoryDTO> GetAsync(long id)
        {
            var category = await _uow.CategoriesRepository.GetAsync(id);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async override Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var category = await _uow.CategoriesRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(category);
        }

        public async override Task<bool> RemoveAsync(long id)
        {
            var category = await _uow.CategoriesRepository.GetAsync(id);
            _uow.CategoriesRepository.Remove(category);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async override Task<bool> UpdateAsync(CategoryDTO entity)
        {
            _uow.CategoriesRepository.Update(_mapper.Map<Category>(entity));
            await _uow.SaveChangesAsync();

            return true;
        }
    }
}
