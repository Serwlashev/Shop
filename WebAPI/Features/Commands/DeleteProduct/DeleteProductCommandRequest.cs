using MediatR;

namespace WebAPI.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public long Id { get; set; }
    }
}
