using MediatR;
using System.Collections.Generic;

namespace Core.Application.Features.Queries.GetAllCategory
{
    public class GetAllCategoryQueryRequest : IRequest<List<GetAllCategoryQueryResponse>>
    {
    }
}
