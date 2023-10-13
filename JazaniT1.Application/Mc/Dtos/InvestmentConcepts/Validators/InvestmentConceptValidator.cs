using FluentValidation;
using JazaniT1.Application.Mc.Dtos.InvestmentConcepts;

namespace JazaniT1.Application.Mc.Dtos.InvestmentConcepts.Validators
{
    public class InvestmentConceptValidator : AbstractValidator<InvestmentConceptSaveDto>
    {
        public InvestmentConceptValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
