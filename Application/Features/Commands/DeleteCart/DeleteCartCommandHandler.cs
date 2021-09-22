using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Features.Commands.DeleteCart
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommandRequest, DeleteCartCommandResponse>
    {
        private readonly IServiceManager _serviceManager;

        public DeleteCartCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<DeleteCartCommandResponse> Handle(DeleteCartCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _serviceManager.CartService.RemoveAsync(request.Id);

            return new DeleteCartCommandResponse
            {
                Succeed = result,
                Message = result ? $"Cart was successfully removed" : $"Cannot delete cart!"
            };
        }
    }
}
