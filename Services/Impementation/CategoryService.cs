using AutoMapper;
using Core.Application.Interfaces;
using Core.Application.DTO;
using Core.Domain.Interfaces.Repository;
using Core.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using System.Threading;

namespace Infrastructure.Services.Impementation
{
    public class CategoryService : BaseService<long, CategoryDTO>, ICategoryService
    {
        public CategoryService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public async override Task<bool> CreateAsync(CategoryDTO entity, CancellationToken token = default)
        {
            _uow.CategoriesRepository.Create(_mapper.Map<Category>(entity));
            await _uow.SaveChangesAsync(token);
            
            return true;
        }

        public async override Task<CategoryDTO> GetAsync(long id, CancellationToken token = default)
        {
            var category = await _uow.CategoriesRepository.GetAsync(id, token);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async override Task<IEnumerable<CategoryDTO>> GetAllAsync(CancellationToken token = default)
        {
            var category = await _uow.CategoriesRepository.GetAllAsync(token);

            return _mapper.Map<IEnumerable<CategoryDTO>>(category);
        }

        public async override Task<bool> RemoveAsync(long id, CancellationToken token = default)
        {
            var category = await _uow.CategoriesRepository.GetAsync(id, token);
            _uow.CategoriesRepository.Remove(category);
            await _uow.SaveChangesAsync(token);

            return true;
        }

        public async override Task<bool> UpdateAsync(CategoryDTO entity, CancellationToken token = default)
        {
            _uow.CategoriesRepository.Update(_mapper.Map<Category>(entity));
            await _uow.SaveChangesAsync(token);

            return true;
        }

        public override Task<IEnumerable<CategoryDTO>> GetByConditionAsync(Expression<Func<CategoryDTO, bool>> predicate, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
