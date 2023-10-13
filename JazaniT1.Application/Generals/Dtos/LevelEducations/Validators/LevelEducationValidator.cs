
using FluentValidation;
using JazaniT1.Application.Generals.Dtos.LevelEducations;

namespace JazaniT1.Application.Generals.Dtos.LevelEducations.Validators
{
    public class LevelEducationValidator : AbstractValidator<LevelEducationSaveDto>
    {
        public LevelEducationValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
