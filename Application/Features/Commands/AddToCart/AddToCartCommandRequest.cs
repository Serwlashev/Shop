using Core.Application.Features.Queries.GetByIdProduct;
using MediatR;
using System;

namespace Core.Application.Features.Commands.AddToCart
{
    public class AddToCartCommandRequest : IRequest<AddToCartCommandResponse>
    {
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public GetByIdProductQueryResponse Product { get; set; }
    }
}
