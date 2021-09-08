using Core.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IServiceManager _serviceManager;

        public DeleteProductCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _serviceManager.ProductService.RemoveAsync(request.Id);

            return new DeleteProductCommandResponse
            {
                Succeed = result,
                Message = result ? $"Product was successfully added" : $"Cannot delete product!"
            };
        }
    }
}
