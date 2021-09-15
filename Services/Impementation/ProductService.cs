using Core.Application.DTO;
using Core.Application.Interfaces;
using AutoMapper;
using Core.Domain.Entity;
using Core.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;

namespace Infrastructure.Services.Impementation
{
    public class ProductService : BaseService<long, ProductDTO>, IProductService
    {
        public ProductService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public async override Task<bool> CreateAsync(ProductDTO entity)
        {
            _uow.ProductsRepository.Create(_mapper.Map<Product>(entity));
            await _uow.SaveChangesAsync();

            return true;
        }

        public async override Task<ProductDTO> GetAsync(long id)
        {
            var product = await _uow.ProductsRepository.GetAsync(id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async override Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _uow.ProductsRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async override Task<bool> RemoveAsync(long id)
        {
            var product = await _uow.ProductsRepository.GetAsync(id);
            _uow.ProductsRepository.Remove(product);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async override Task<bool> UpdateAsync(ProductDTO entity)
        {
            _uow.ProductsRepository.Update(_mapper.Map<Product>(entity));
            await _uow.SaveChangesAsync();

            return true;
        }

        public override Task<IEnumerable<ProductDTO>> GetByConditionAsync(Expression<Func<ProductDTO, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
