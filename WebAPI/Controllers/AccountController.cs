﻿using WebAPI.Features.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<LoginCommandResponse> LoginAsync([FromQuery] LoginCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
