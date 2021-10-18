using MediatR;

namespace WebAPI.Features.Commands.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<DeleteCategoryCommandResponse>
    {
        public long Id { get; set; }
    }
}
