using FluentValidation;

namespace JazaniT1.Application.Admins.Dtos.MeasureUnits.Validators
{
    public class MeasureUnitValidator: AbstractValidator<MeasureUnitSaveDto>
    {
        public MeasureUnitValidator() 
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Symbol).NotNull().NotEmpty();
        }
    }
}
