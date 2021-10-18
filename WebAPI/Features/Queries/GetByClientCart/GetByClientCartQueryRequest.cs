using MediatR;

namespace WebAPI.Features.Queries.GetByClientCart
{
    public class GetByClientCartQueryRequest : IRequest<GetByClientCartQueryResponse>
    {
        public string UserId { get; set; }
    }
}
