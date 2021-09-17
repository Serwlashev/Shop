using FluentValidation;

namespace Core.Application.Features.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandValidator()
        {
            RuleFor(u => u.Email)
                .NotNull()
                .WithMessage("Email cannot be null")
                .EmailAddress();

            RuleFor(u => u.Password)
                .NotNull()
                .WithMessage("Password cannot be null")
                .MaximumLength(20)
                .MinimumLength(8)
                .WithMessage("Password should be 8 - 20 symbols")
                .Matches("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$")
                .WithMessage("Password must include numbers, uppercase and lowercase letters");
        }
    }
}
