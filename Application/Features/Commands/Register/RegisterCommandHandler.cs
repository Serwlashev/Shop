using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Features.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        private readonly IServiceManager _serviceManager;

        public RegisterCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _serviceManager.ProductService.RemoveAsync(request.Id);

            return new RegisterCommandResponse
            {
                Succeed = result,
                Message = result ? $"Product was successfully removed" : $"Cannot delete product!"
            };
        }
    }
}
