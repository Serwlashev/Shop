using MediatR;
using System.Collections.Generic;

namespace Core.Application.Features.Queries.FindProducts
{
    public class FindProductsQueryRequest : IRequest<List<FindProductsQueryResponse>>
    {
        public string SearchText { get; set; }

    }
}
