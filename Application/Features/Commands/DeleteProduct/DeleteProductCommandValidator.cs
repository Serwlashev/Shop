using FluentValidation;

namespace Core.Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(p => p.Id)
            .NotNull()
            .WithMessage("Product Id cannot be null")
            .GreaterThan(0)
            .WithMessage("Product Id should be greater then zero");
        }
    }
}
