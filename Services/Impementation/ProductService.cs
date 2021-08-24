using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using Services.DTO;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Impementation
{
    public class ProductService : BaseService<long, ProductDTO>, IProductService
    {
        public ProductService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public async override void Create(ProductDTO entity)
        {
            _uow.ProductsRepository.Create(_mapper.Map<Product>(entity));
            await _uow.SaveChangesAsync();
        }

        public async override Task<ProductDTO> Get(long id)
        {
            var category = await _uow.ProductsRepository.Get(id);

            return _mapper.Map<ProductDTO>(category);
        }

        public async override Task<IEnumerable<ProductDTO>> GetAll()
        {
            var category = await _uow.ProductsRepository.GetAll();

            return _mapper.Map<IEnumerable<ProductDTO>>(category);
        }

        public async override void Remove(long id)
        {
            _uow.ProductsRepository.Remove(id);
            await _uow.SaveChangesAsync();
        }

        public async override void Update(ProductDTO entity)
        {
            _uow.ProductsRepository.Update(_mapper.Map<Product>(entity));
            await _uow.SaveChangesAsync();
        }
    }
}
