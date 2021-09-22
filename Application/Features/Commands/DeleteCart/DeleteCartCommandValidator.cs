using FluentValidation;

namespace Core.Application.Features.Commands.DeleteCart
{
    public class DeleteCartCommandValidator : AbstractValidator<DeleteCartCommandRequest>
    {
        public DeleteCartCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .WithMessage("Cart Id cannot be null")
                .GreaterThan(0)
                .WithMessage("Cart Id should be greater then zero");
        }
    }
}
