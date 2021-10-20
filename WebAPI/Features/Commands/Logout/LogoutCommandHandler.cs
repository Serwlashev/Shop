using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Features.Commands.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommandRequest, LogoutCommandResponse>
    {
        private readonly IServiceManager _serviceManager;

        public LogoutCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<LogoutCommandResponse> Handle(LogoutCommandRequest request, CancellationToken token = default)
        {
            bool result = await _serviceManager.ProductService.RemoveAsync(request.Id, token);

            return new LogoutCommandResponse
            {
                Succeed = result,
                Message = result ? $"Product was successfully removed" : $"Cannot delete product!"
            };
        }
    }
}
