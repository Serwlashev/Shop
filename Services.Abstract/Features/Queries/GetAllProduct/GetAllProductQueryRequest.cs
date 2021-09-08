using MediatR;
using System.Collections.Generic;

namespace Core.Application.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    {
    }
}
