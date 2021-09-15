using MediatR;

namespace Core.Application.Features.Commands.Register
{
    public class RegisterCommandRequest : IRequest<RegisterCommandResponse>
    {
        public long Id { get; set; }
    }
}
