using Core.Application.Features.Commands.CreateProduct;
using Core.Application.Features.Commands.DeleteProduct;
using Core.Application.Features.Commands.UpdateProduct;
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

        [HttpPost]
        public async Task<CreateProductCommandResponse> CreateProduct([FromQuery] CreateProductCommandRequest request)
            => await _mediator.Send(request);

        [HttpGet]
        public async Task<List<GetAllProductQueryResponse>> GetAllProducts()
            =>  await _mediator.Send(new GetAllProductQueryRequest());

        [HttpGet("{id}")]
        public async Task<GetByIdProductQueryResponse> GetByIdProduct([FromQuery] GetByIdProductQueryRequest request)
             => await _mediator.Send(request);

        [HttpPut]
        public async Task<UpdateProductCommandResponse> UpdateProduct([FromQuery] UpdateProductCommandRequest request)
             => await _mediator.Send(request);

        [HttpDelete]
        [Route("{id}")]
        public async Task<DeleteProductCommandResponse> DeleteProduct([FromQuery] DeleteProductCommandRequest request)
             => await _mediator.Send(request);
    }
}
