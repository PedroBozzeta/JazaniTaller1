using FluentValidation;

namespace JazaniT1.Application.Admins.Dtos.PeriodTypes.Validators
{
    public class PeriodTypeValidator:AbstractValidator<PeriodTypeSaveDto>
    {
        public PeriodTypeValidator() {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
