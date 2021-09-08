using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Features.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly IServiceManager _serviceManager;

        public DeleteCategoryCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _serviceManager.CategoryService.RemoveAsync(request.Id);

            return new DeleteCategoryCommandResponse
            {
                Succeed = result,
                Message = result ? $"Category was successfully removed" : $"Cannot delete category!"
            };
        }
    }
}
