using FluentValidation;

namespace JazaniT1.Application.Admins.Dtos.InvestmentTypes.Validators
{
    public class InvestmentTypeValidator : AbstractValidator<InvestmentTypeSaveDto>
    {
        public InvestmentTypeValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
