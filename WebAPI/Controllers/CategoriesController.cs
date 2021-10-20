using WebAPI.Features.Commands.CreateCategory;
using WebAPI.Features.Commands.DeleteCategory;
using WebAPI.Features.Commands.UpdateCategory;
using WebAPI.Features.Queries.GetAllCategory;
using WebAPI.Features.Queries.GetByIdCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CreateCategoryCommandResponse> CreateCategory([FromBody] CreateCategoryCommandRequest request, CancellationToken token)
            => await _mediator.Send(request, token);
        
        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<List<GetAllCategoryQueryResponse>> GetAllCategories(CancellationToken token)
            => await _mediator.Send(new GetAllCategoryQueryRequest(), token);

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<GetByIdCategoryQueryResponse> GetByIdCategory([FromHeader] GetByIdCategoryQueryRequest request, CancellationToken token)
            => await _mediator.Send(request, token);

        [HttpPut]
        public async Task<UpdateCategoryCommandResponse> UpdateCategory([FromBody] UpdateCategoryCommandRequest request, CancellationToken token)
             => await _mediator.Send(request, token);

        [HttpDelete]
        [Route("{id}")]
        public async Task<DeleteCategoryCommandResponse> DeleteCategory([FromHeader] DeleteCategoryCommandRequest request, CancellationToken token)
             => await _mediator.Send(request, token);
    }
}
