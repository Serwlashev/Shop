using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IServiceManager _serviceManager;

        public DeleteProductCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken token = default)
        {
            bool result = await _serviceManager.ProductService.RemoveAsync(request.Id, token);

            return new DeleteProductCommandResponse
            {
                Succeed = result,
                Message = result ? $"Product was successfully removed" : $"Cannot delete product!"
            };
        }
    }
}
