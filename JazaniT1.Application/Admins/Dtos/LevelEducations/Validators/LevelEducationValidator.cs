
using FluentValidation;

namespace JazaniT1.Application.Admins.Dtos.LevelEducations.Validators
{
    public class LevelEducationValidator : AbstractValidator<LevelEducationSaveDto>
    {
        public LevelEducationValidator() {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
