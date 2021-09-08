using Core.Application.Features.Commands.CreateCategory;
using Core.Application.Features.Commands.DeleteCategory;
using Core.Application.Features.Commands.UpdateCategory;
using Core.Application.Features.Queries.GetAllCategory;
using Core.Application.Features.Queries.GetByIdCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<CreateCategoryCommandResponse> CreateCategory([FromQuery] CreateCategoryCommandRequest request)
            => await _mediator.Send(request);

        [HttpGet]
        public async Task<List<GetAllCategoryQueryResponse>> GetAllCategories()
            => await _mediator.Send(new GetAllCategoryQueryRequest());

        [HttpGet("{id}")]
        public async Task<GetByIdCategoryQueryResponse> GetByIdCategory([FromQuery] GetByIdCategoryQueryRequest request)
            => await _mediator.Send(request);

        [HttpPut]
        public async Task<UpdateCategoryCommandResponse> UpdateCategory([FromQuery] UpdateCategoryCommandRequest request)
             => await _mediator.Send(request);

        [HttpDelete]
        [Route("{id}")]
        public async Task<DeleteCategoryCommandResponse> DeleteCategory([FromQuery] DeleteCategoryCommandRequest request)
             => await _mediator.Send(request);
    }
}
