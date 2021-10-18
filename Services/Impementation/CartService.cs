using AutoMapper;
using Core.Application.DTO;
using Core.Application.Interfaces;
using Core.Domain.Entity;
using Core.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Services.Impementation
{
    public class CartService : BaseService<long, CartItemDTO>, ICartService
    {
        public CartService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public async override Task<bool> CreateAsync(CartItemDTO entity, CancellationToken token = default)
        {
            _uow.CartRepository.Create(_mapper.Map<CartItem>(entity));
            await _uow.SaveChangesAsync(token);

            return true;
        }

        public override Task<IEnumerable<CartItemDTO>> GetAllAsync(CancellationToken token = default)
            => throw new NotImplementedException();


        public async override Task<CartItemDTO> GetAsync(long id, CancellationToken token = default)
        {
            var cartItem = await _uow.CartRepository.GetAsync(id, token);

            return _mapper.Map<CartItemDTO>(cartItem);
        }

        public async override Task<IEnumerable<CartItemDTO>> GetByConditionAsync(Expression<Func<CartItemDTO, bool>> predicate, CancellationToken token = default)
        {
            var users = await _uow.CartRepository.GetByConditionAsync(_mapper.Map<Expression<Func<CartItem, bool>>>(predicate), token);

            return _mapper.Map<IEnumerable<CartItemDTO>>(users);
        }

        public async override Task<bool> RemoveAsync(long id, CancellationToken token = default)
        {
            var cartItem = await _uow.CartRepository.GetAsync(id, token);
            _uow.CartRepository.Remove(cartItem);
            await _uow.SaveChangesAsync(token);

            return true;
        }

        public async override Task<bool> UpdateAsync(CartItemDTO entity, CancellationToken token = default)
        {
            _uow.CartRepository.Update(_mapper.Map<CartItem>(entity));
            await _uow.SaveChangesAsync(token);

            return true;
        }
    }
}
