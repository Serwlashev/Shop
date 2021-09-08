using MediatR;

namespace Core.Application.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public long Id { get; set; }
    }
}
