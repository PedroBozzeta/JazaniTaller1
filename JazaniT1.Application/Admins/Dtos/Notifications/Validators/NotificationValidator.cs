using FluentValidation;

namespace JazaniT1.Application.Admins.Dtos.Notifications.Validators
{
    public class NotificationValidator: AbstractValidator<NotificationSaveDto>
    {
        public NotificationValidator() {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
        
    }
}
