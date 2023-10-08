using FluentValidation;

namespace JazaniT1.Application.Admins.Dtos.Investments.Validators
{
    public class InvestmentValidator : AbstractValidator<InvestmentSaveDto>
    {
        public InvestmentValidator()
        {
            RuleFor(x => x.AmountInvestd).NotNull().NotEmpty();
            RuleFor(x => x.MiningConcessionId).NotNull().NotEmpty();
            RuleFor(x => x.InvestmentTypeId).NotNull().NotEmpty();
            RuleFor(x => x.HolderId).NotNull().NotEmpty();
            }
    }
}