using MediatR;

namespace WebAPI.Features.Commands.Register
{
    public class RegisterCommandRequest : IRequest<RegisterCommandResponse>
    {
        public long Id { get; set; }
    }
}
