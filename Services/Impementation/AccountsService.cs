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
    public class AccountsService : BaseService<long, UserDTO>, IAccountsService
    {
        public AccountsService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public async override Task<bool> CreateAsync(UserDTO entity)
        {
            _uow.AccountsRepository.Create(_mapper.Map<User>(entity));
            await _uow.SaveChangesAsync();

            return true;
        }

        public async override Task<UserDTO> GetAsync(long id)
        {
            var category = await _uow.AccountsRepository.GetAsync(id);

            return _mapper.Map<UserDTO>(category);
        }

        public async override Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var category = await _uow.AccountsRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserDTO>>(category);
        }

        public async override Task<bool> RemoveAsync(long id)
        {
            var category = await _uow.AccountsRepository.GetAsync(id);
            _uow.AccountsRepository.Remove(category);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async override Task<bool> UpdateAsync(UserDTO entity)
        {
            _uow.AccountsRepository.Update(_mapper.Map<User>(entity));
            await _uow.SaveChangesAsync();

            return true;
        }

        public async override Task<IEnumerable<UserDTO>> GetByConditionAsync(Expression<Func<UserDTO, bool>> predicate)
        {
            var users = await _uow.AccountsRepository.GetByConditionAsync(_mapper.Map<Expression<Func<User, bool>>>(predicate));

            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }
    }
}
