using Core.Application.Features.Queries.GetByIdProduct;
using System;

namespace Core.Application.Features.Queries.GetByClientCart
{
    public class GetByClientCartQueryResponse
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public GetByIdProductQueryResponse Product { get; set; }

    }
}
