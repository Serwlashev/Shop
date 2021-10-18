using FluentValidation;

namespace WebAPI.Features.Commands.UpdateCart
{
    public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommandRequest>
    {
        public UpdateCartCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .WithMessage("Cart Id cannot be null")
                .GreaterThan(0)
                .WithMessage("Cart Id should be greater then zero");

            RuleFor(c => c.UserId)
                .NotNull()
                .WithMessage("User cart Id cannot be null");

            RuleFor(c => c.DateCreated)
                .NotNull()
                .WithMessage("Date created cannot be null")
                .LessThanOrEqualTo(System.DateTime.Now)
                .WithMessage("Cannot create item in the future");

            RuleFor(c => c.Quantity)
                .NotNull()
                .WithMessage("Quantity cannot be null")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Cannot set quantity less then zero");
        }
    }
}
