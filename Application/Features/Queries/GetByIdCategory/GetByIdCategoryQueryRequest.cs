using MediatR;

namespace Core.Application.Features.Queries.GetByIdCategory
{
    public class GetByIdCategoryQueryRequest : IRequest<GetByIdCategoryQueryResponse>
    {
        public long Id { get; set; }
    }
}
