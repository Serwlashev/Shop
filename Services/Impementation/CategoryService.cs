using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using Services.DTO;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Impementation
{
    public class CategoryService : BaseService<long, CategoryDTO>, ICategoryService
    {
        public CategoryService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public async override void Create(CategoryDTO entity)
        {
            _uow.CategoriesRepository.Create(_mapper.Map<Category>(entity));
            await _uow.SaveChangesAsync();
        }

        public async override Task<CategoryDTO> Get(long id)
        {
            var category = await _uow.CategoriesRepository.Get(id);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async override Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var category = await _uow.CategoriesRepository.GetAll();

            return _mapper.Map<IEnumerable<CategoryDTO>>(category);
        }

        public async override void Remove(long id)
        {
            _uow.CategoriesRepository.Remove(id);
            await _uow.SaveChangesAsync();
        }

        public async override void Update(CategoryDTO entity)
        {
            _uow.CategoriesRepository.Update(_mapper.Map<Category>(entity));
            await _uow.SaveChangesAsync();
        }
    }
}
