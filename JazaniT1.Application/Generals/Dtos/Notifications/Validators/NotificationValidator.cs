using FluentValidation;
using JazaniT1.Application.Generals.Dtos.Notifications;

namespace JazaniT1.Application.Generals.Dtos.Notifications.Validators
{
    public class NotificationValidator : AbstractValidator<NotificationSaveDto>
    {
        public NotificationValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }

    }
}
