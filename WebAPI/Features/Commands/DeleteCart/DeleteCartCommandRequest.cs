using MediatR;

namespace WebAPI.Features.Commands.DeleteCart
{
    public class DeleteCartCommandRequest : IRequest<DeleteCartCommandResponse>
    {
        public long Id { get; set; }
    }
}
