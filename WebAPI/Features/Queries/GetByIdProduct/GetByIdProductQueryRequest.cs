using MediatR;

namespace WebAPI.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public long Id { get; set; }
    }
}
