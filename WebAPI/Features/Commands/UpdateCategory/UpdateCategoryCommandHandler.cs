using Core.Application.DTO;
using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Features.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly IServiceManager _serviceManager;

        public UpdateCategoryCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken token = default)
        {
            CategoryDTO category = new CategoryDTO
            {
                Id = request.Id,
                Name = request.Name
            };

            bool result = await _serviceManager.CategoryService.UpdateAsync(category, token);

            return new UpdateCategoryCommandResponse
            {
                Succeed = result,
                Message = result ? $"Category { category.Name } was successfully updated" : $"Cannot update category { category.Name }!"
            };
        }
    }
}
