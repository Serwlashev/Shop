using Core.Application.DTO;
using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Features.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly IServiceManager _serviceManager;
        
        public CreateCategoryCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken token = default)
        {
            CategoryDTO category = new CategoryDTO
            {
                Name = request.Name
            };

            bool result = await _serviceManager.CategoryService.CreateAsync(category, token);

            return new CreateCategoryCommandResponse
            {
                Succeed = result,
                Message = result ? $"Category { category.Name } was successfully added" : $"Cannot add category { category.Name }!"
            };
        }
    }
}
