using Core.Application.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Features.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly IServiceManager _serviceManager;

        public LoginCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken token = default)
        {
            var accounts = await _serviceManager.AccountsService.GetByConditionAsync(user => user.Email == request.Email && user.Password == request.Password, token);

            var succeed = accounts.Count() == 1;
            return new LoginCommandResponse
            {
                Succeed = succeed,
                Message = succeed ? $"Logged in" : $"Cannot log in, incorrect credentials!"
            };
        }
    }
}
