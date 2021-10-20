using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Features.Commands.DeleteCart
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommandRequest, DeleteCartCommandResponse>
    {
        private readonly IServiceManager _serviceManager;

        public DeleteCartCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<DeleteCartCommandResponse> Handle(DeleteCartCommandRequest request, CancellationToken token = default)
        {
            bool result = await _serviceManager.CartService.RemoveAsync(request.Id, token);

            return new DeleteCartCommandResponse
            {
                Succeed = result,
                Message = result ? $"Cart was successfully removed" : $"Cannot delete cart!"
            };
        }
    }
}
