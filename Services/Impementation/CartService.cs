using AutoMapper;
using Core.Application.DTO;
using Core.Application.Interfaces;
using Core.Domain.Entity;
using Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Services.Impementation
{
    public class CartService : BaseService<long, CartItemDTO>, ICartService
    {
        public CartService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public async override Task<bool> CreateAsync(CartItemDTO entity)
        {
            _uow.CartRepository.Create(_mapper.Map<CartItem>(entity));
            await _uow.SaveChangesAsync();

            return true;
        }

        public override Task<IEnumerable<CartItemDTO>> GetAllAsync()
            => throw new NotImplementedException();


        public async override Task<CartItemDTO> GetAsync(long id)
        {
            var cartItem = await _uow.CartRepository.GetAsync(id);

            return _mapper.Map<CartItemDTO>(cartItem);
        }

        public override Task<IEnumerable<CartItemDTO>> GetByConditionAsync(Expression<Func<CartItemDTO, bool>> predicate)
            => throw new NotImplementedException();

        public async override Task<bool> RemoveAsync(long id)
        {
            var cartItem = await _uow.CartRepository.GetAsync(id);
            _uow.CartRepository.Remove(cartItem);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async override Task<bool> UpdateAsync(CartItemDTO entity)
        {
            _uow.CartRepository.Update(_mapper.Map<CartItem>(entity));
            await _uow.SaveChangesAsync();

            return true;
        }
    }
}
