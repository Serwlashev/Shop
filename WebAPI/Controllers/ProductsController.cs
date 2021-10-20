using WebAPI.Features.Commands.CreateProduct;
using WebAPI.Features.Commands.DeleteProduct;
using WebAPI.Features.Commands.UpdateProduct;
using WebAPI.Features.Queries.FindProducts;
using WebAPI.Features.Queries.GetAllProduct;
using WebAPI.Features.Queries.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

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
        public async Task<CreateProductCommandResponse> CreateProduct([FromBody] CreateProductCommandRequest request, CancellationToken token)
            => await _mediator.Send(request, token);

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<List<GetAllProductQueryResponse>> GetAllProducts(CancellationToken token)
            =>  await _mediator.Send(new GetAllProductQueryRequest(), token);

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<GetByIdProductQueryResponse> GetByIdProduct([FromHeader] GetByIdProductQueryRequest request, CancellationToken token)
             => await _mediator.Send(request, token);

        [AllowAnonymous]
        [HttpGet("find/{searchText}")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<List<FindProductsQueryResponse>> FindProducts([FromHeader] FindProductsQueryRequest request, CancellationToken token)
             => await _mediator.Send(request, token);

        [HttpPut]
        public async Task<UpdateProductCommandResponse> UpdateProduct([FromBody] UpdateProductCommandRequest request, CancellationToken token)
             => await _mediator.Send(request, token);

        [HttpDelete]
        [Route("{id}")]
        public async Task<DeleteProductCommandResponse> DeleteProduct([FromHeader] DeleteProductCommandRequest request, CancellationToken token)
             => await _mediator.Send(request, token);
    }
}
