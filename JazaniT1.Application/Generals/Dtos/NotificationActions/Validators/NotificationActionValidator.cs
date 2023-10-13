using FluentValidation;
using JazaniT1.Application.Generals.Dtos.NotificationActions;

namespace JazaniT1.Application.Generals.Dtos.NotificationActions.Validators
{
    public class NotificationActionValidator : AbstractValidator<NotificationActionSaveDto>
    {
        public NotificationActionValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
