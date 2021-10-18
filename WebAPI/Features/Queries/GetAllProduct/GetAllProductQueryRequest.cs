using MediatR;
using System.Collections.Generic;

namespace WebAPI.Features.Queries.GetAllProduct
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    {
    }
}
