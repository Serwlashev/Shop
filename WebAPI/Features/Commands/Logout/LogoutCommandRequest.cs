using MediatR;

namespace WebAPI.Features.Commands.Logout
{
    public class LogoutCommandRequest : IRequest<LogoutCommandResponse>
    {
        public long Id { get; set; }
    }
}
