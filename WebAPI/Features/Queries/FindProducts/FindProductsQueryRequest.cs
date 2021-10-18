using MediatR;
using System.Collections.Generic;

namespace WebAPI.Features.Queries.FindProducts
{
    public class FindProductsQueryRequest : IRequest<List<FindProductsQueryResponse>>
    {
        public string SearchText { get; set; }

    }
}
