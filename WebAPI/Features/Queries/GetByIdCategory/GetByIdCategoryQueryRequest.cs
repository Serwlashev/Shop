using MediatR;

namespace WebAPI.Features.Queries.GetByIdCategory
{
    public class GetByIdCategoryQueryRequest : IRequest<GetByIdCategoryQueryResponse>
    {
        public long Id { get; set; }
    }
}
