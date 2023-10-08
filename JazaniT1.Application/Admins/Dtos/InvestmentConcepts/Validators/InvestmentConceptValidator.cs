using FluentValidation;

namespace JazaniT1.Application.Admins.Dtos.InvestmentConcepts.Validators
{
    public class InvestmentConceptValidator : AbstractValidator<InvestmentConceptSaveDto>
    {
        public InvestmentConceptValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
