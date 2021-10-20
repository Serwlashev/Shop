using WebAPI.Features.Commands.AddToCart;
using WebAPI.Features.Commands.DeleteCart;
using WebAPI.Features.Commands.UpdateCart;
using WebAPI.Features.Queries.GetByClientCart;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<AddToCartCommandResponse> CreateCart([FromBody] AddToCartCommandRequest request, CancellationToken token)
            => await _mediator.Send(request, token);

        [HttpGet("{id}")]
        public async Task<GetByClientCartQueryResponse> GetByClientCart([FromHeader] GetByClientCartQueryRequest request, CancellationToken token)
             => await _mediator.Send(request, token);

        [HttpPut]
        public async Task<UpdateCartCommandResponse> UpdateCart([FromBody] UpdateCartCommandRequest request, CancellationToken token)
             => await _mediator.Send(request, token);

        [HttpDelete]
        [Route("{id}")]
        public async Task<DeleteCartCommandResponse> DeleteCart([FromHeader] DeleteCartCommandRequest request, CancellationToken token)
             => await _mediator.Send(request, token);
    }
}
