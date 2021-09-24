using Core.Application.Features.Commands.AddToCart;
using Core.Application.Features.Commands.DeleteCart;
using Core.Application.Features.Commands.UpdateCart;
using Core.Application.Features.Queries.GetByClientCart;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using WebAPI.Hubs;

namespace WebAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<CartHub> _hubContext;
        public CartController(IMediator mediator, IHubContext<CartHub> hubContext)
        {
            _mediator = mediator;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<AddToCartCommandResponse> CreateCart([FromBody] AddToCartCommandRequest request)
            => await _mediator.Send(request);

        [HttpGet("{id}")]
        public async Task<GetByClientCartQueryResponse> GetByClientCart([FromHeader] GetByClientCartQueryRequest request)
             => await _mediator.Send(request);

        [HttpPut]
        public async Task<UpdateCartCommandResponse> UpdateCart([FromBody] UpdateCartCommandRequest request)
             => await _mediator.Send(request);

        [HttpDelete]
        [Route("{id}")]
        public async Task<DeleteCartCommandResponse> DeleteCart([FromHeader] DeleteCartCommandRequest request)
             => await _mediator.Send(request);
    }
}
