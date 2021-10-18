using FluentValidation;

namespace WebAPI.Features.Commands.DeleteCategory
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommandRequest>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .WithMessage("Category Id cannot be null")
                .GreaterThan(0)
                .WithMessage("Category Id should be greater then zero");
        }
    }
}
