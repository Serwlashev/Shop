using MediatR;

namespace Core.Application.Features.Commands.DeleteCart
{
    public class DeleteCartCommandRequest : IRequest<DeleteCartCommandResponse>
    {
        public long Id { get; set; }
    }
}
