using FluentValidation;
using JazaniT1.Application.Generals.Dtos.PeriodTypes;

namespace JazaniT1.Application.Generals.Dtos.PeriodTypes.Validators
{
    public class PeriodTypeValidator : AbstractValidator<PeriodTypeSaveDto>
    {
        public PeriodTypeValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
