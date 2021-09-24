using FluentValidation;

namespace Core.Application.Features.Queries.GetByClientCart
{
    public class GetByClientCartValidator : AbstractValidator<GetByClientCartQueryRequest>
    {
        public GetByClientCartValidator()
        {
            RuleFor(p => p.UserId)
                .NotNull()
                .WithMessage("User Id cannot be null")
                .Length(1, 100)
                .WithMessage("User Id should be greater then zero and smaller then 100 symbols");
        }
    }
}
