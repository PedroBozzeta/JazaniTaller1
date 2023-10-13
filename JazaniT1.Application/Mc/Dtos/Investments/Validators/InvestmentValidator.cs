using FluentValidation;
using JazaniT1.Application.Mc.Dtos.Investments;

namespace JazaniT1.Application.Mc.Dtos.Investments.Validators
{
    public class InvestmentValidator : AbstractValidator<InvestmentSaveDto>
    {
        public InvestmentValidator()
        {
            RuleFor(x => x.AmountInvestd).NotEmpty();
            RuleFor(x => x.MiningConcessionId).NotEmpty();
            RuleFor(x => x.InvestmentTypeId).NotEmpty();
            RuleFor(x => x.HolderId).NotEmpty();
        }
    }
}