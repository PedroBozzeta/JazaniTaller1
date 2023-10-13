using FluentValidation;
using JazaniT1.Application.Mc.Dtos.MiningConcessions;

namespace JazaniT1.Application.Mc.Dtos.MiningConcessions.Validators
{
    public class MiningConcessionValidator : AbstractValidator<MiningConcessionSaveDto>
    {
        public MiningConcessionValidator()
        {
            RuleFor(x => x.Code).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
