using FluentValidation;

namespace JazaniT1.Application.Admins.Dtos.NotificationActions.Validators
{
    public class NotificationActionValidator: AbstractValidator<NotificationActionSaveDto>
    {
        public NotificationActionValidator() 
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
