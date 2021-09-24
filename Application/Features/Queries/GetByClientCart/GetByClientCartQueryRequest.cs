using MediatR;

namespace Core.Application.Features.Queries.GetByClientCart
{
    public class GetByClientCartQueryRequest : IRequest<GetByClientCartQueryResponse>
    {
        public string UserId { get; set; }
    }
}
