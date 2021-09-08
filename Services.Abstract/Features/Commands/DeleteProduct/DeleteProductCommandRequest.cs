using MediatR;

namespace Core.Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public long Id { get; set; }
    }
}
