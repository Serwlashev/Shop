using Core.Application.DTO;
using Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Features.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly IServiceManager _serviceManager;
        
        public CreateCategoryCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            CategoryDTO category = new CategoryDTO
            {
                Name = request.Name
            };

            bool result = await _serviceManager.CategoryService.CreateAsync(category);

            return new CreateCategoryCommandResponse
            {
                Succeed = result,
                Message = result ? $"Category { category.Name } was successfully added" : $"Cannot add category { category.Name }!"
            };
        }
    }
}
