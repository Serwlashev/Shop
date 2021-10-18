using MediatR;
using System.Collections.Generic;

namespace WebAPI.Features.Queries.GetAllCategory
{
    public class GetAllCategoryQueryRequest : IRequest<List<GetAllCategoryQueryResponse>>
    {
    }
}
