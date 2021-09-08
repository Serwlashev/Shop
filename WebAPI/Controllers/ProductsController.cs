using Core.Application.Features.Queries.GetAllProduct;
using Core.Application.Features.Queries.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllProductQueryResponse>> GetAllProducts()
            =>  await _mediator.Send(new GetAllProductQueryRequest());

        [HttpGet("{Id}")]
        public async Task<GetByIdProductQueryResponse> GetByIdProduct([FromQuery] GetByIdProductQueryRequest request)
             => await _mediator.Send(request);
    }
}
