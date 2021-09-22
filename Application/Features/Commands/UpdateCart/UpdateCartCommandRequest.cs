using Core.Application.Features.Queries.GetByIdProduct;
using MediatR;
using System;

namespace Core.Application.Features.Commands.UpdateCart
{
    public class UpdateCartCommandRequest : IRequest<UpdateCartCommandResponse>
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public GetByIdProductQueryResponse Product { get; set; }
    }
}
