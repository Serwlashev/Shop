using MediatR;

namespace Core.Application.Features.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
