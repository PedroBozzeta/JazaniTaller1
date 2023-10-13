using FluentValidation;
using JazaniT1.Application.Mc.Dtos.InvestmentTypes;

namespace JazaniT1.Application.Mc.Dtos.InvestmentTypes.Validators
{
    public class InvestmentTypeValidator : AbstractValidator<InvestmentTypeSaveDto>
    {
        public InvestmentTypeValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
