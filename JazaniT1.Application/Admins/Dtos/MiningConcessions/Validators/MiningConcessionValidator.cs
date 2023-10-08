using FluentValidation;

namespace JazaniT1.Application.Admins.Dtos.MiningConcessions.Validators
{
    public class MiningConcessionValidator: AbstractValidator<MiningConcessionSaveDto>
    {
        public MiningConcessionValidator()
        {
            RuleFor(x => x.Code).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
