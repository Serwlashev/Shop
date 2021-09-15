using MediatR;

namespace Core.Application.Features.Commands.Logout
{
    public class LogoutCommandRequest : IRequest<LogoutCommandResponse>
    {
        public long Id { get; set; }
    }
}
