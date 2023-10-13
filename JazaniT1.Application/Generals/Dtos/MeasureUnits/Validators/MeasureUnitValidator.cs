using FluentValidation;
using JazaniT1.Application.Generals.Dtos.MeasureUnits;

namespace JazaniT1.Application.Generals.Dtos.MeasureUnits.Validators
{
    public class MeasureUnitValidator : AbstractValidator<MeasureUnitSaveDto>
    {
        public MeasureUnitValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Symbol).NotNull().NotEmpty();
        }
    }
}
