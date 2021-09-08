using Core.Application.Features.Queries.GetByIdCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<GetByIdCategoryQueryResponse> GetByIdCategory([FromQuery] GetByIdCategoryQueryRequest request)
            => await _mediator.Send(request);
    }
}
