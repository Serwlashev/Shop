using MediatR;

namespace WebAPI.Features.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
