using WebAPI.Features.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;

namespace WebAPI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/token")]
        public async Task<LoginCommandResponse> LoginAsync([FromQuery] LoginCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
    }
}
