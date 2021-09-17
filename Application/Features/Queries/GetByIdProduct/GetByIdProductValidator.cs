using FluentValidation;

namespace Core.Application.Features.Queries.GetByIdProduct
{
    public class GetByIdProductValidator : AbstractValidator<GetByIdProductQueryRequest>
    {
        public GetByIdProductValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .WithMessage("Product Id cannot be null")
                .GreaterThan(1)
                .WithMessage("Product Id should be greater then zero");
        }
    }
}
