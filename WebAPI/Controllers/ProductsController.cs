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
        public async Task<CreateProductCommandResponse> CreateProduct([FromBody] CreateProductCommandRequest request)
            => await _mediator.Send(request);

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<List<GetAllProductQueryResponse>> GetAllProducts()
            =>  await _mediator.Send(new GetAllProductQueryRequest());

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<GetByIdProductQueryResponse> GetByIdProduct([FromHeader] GetByIdProductQueryRequest request)
             => await _mediator.Send(request);

        [AllowAnonymous]
        [HttpGet("find/{searchText}")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<List<FindProductsQueryResponse>> FindProducts([FromHeader] FindProductsQueryRequest request)
             => await _mediator.Send(request);

        [HttpPut]
        public async Task<UpdateProductCommandResponse> UpdateProduct([FromBody] UpdateProductCommandRequest request)
             => await _mediator.Send(request);

        [HttpDelete]
        [Route("{id}")]
        public async Task<DeleteProductCommandResponse> DeleteProduct([FromHeader] DeleteProductCommandRequest request)
             => await _mediator.Send(request);
    }
}
