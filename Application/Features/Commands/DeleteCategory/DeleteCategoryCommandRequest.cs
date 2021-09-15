using MediatR;

namespace Core.Application.Features.Commands.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<DeleteCategoryCommandResponse>
    {
        public long Id { get; set; }
    }
}
