using Core.Application.DTO;
using Core.Application.Interfaces;
using AutoMapper;
using Core.Domain.Entity;
using Core.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using System.Threading;

namespace Infrastructure.Services.Impementation
{
    public class ProductService : BaseService<long, ProductDTO>, IProductService
    {
        public ProductService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public async override Task<bool> CreateAsync(ProductDTO entity, CancellationToken token = default)
        {
            _uow.ProductsRepository.Create(_mapper.Map<Product>(entity));
            await _uow.SaveChangesAsync(token);

            return true;
        }

        public async override Task<ProductDTO> GetAsync(long id, CancellationToken token = default)
        {
            var product = await _uow.ProductsRepository.GetAsync(id, token);

            return _mapper.Map<ProductDTO>(product);
        }

        public async override Task<IEnumerable<ProductDTO>> GetAllAsync(CancellationToken token = default)
        {
            var products = await _uow.ProductsRepository.GetAllAsync(token);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async override Task<bool> RemoveAsync(long id, CancellationToken token = default)
        {
            var product = await _uow.ProductsRepository.GetAsync(id, token);
            _uow.ProductsRepository.Remove(product);
            await _uow.SaveChangesAsync(token);

            return true;
        }

        public async override Task<bool> UpdateAsync(ProductDTO entity, CancellationToken token = default)
        {
            _uow.ProductsRepository.Update(_mapper.Map<Product>(entity));
            await _uow.SaveChangesAsync(token);

            return true;
        }

        public override Task<IEnumerable<ProductDTO>> GetByConditionAsync(Expression<Func<ProductDTO, bool>> predicate, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDTO>> FindProductsAsync(string searchText, CancellationToken token = default)
        {
            var products = await _uow.ProductsRepository.FindProductsAsync(searchText, token);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}
