using FluentValidation;

namespace OperationService.Event.EventValidators
{
    public class RoomNotificationEventValidator : AbstractValidator<RoomNotificationEvent>
    {
        public RoomNotificationEventValidator()
        {
            RuleFor(e => e.RoomId)
                .NotEmpty().WithMessage("Room Notification action required RoomId");

            RuleFor(e => e.MessageContent)
                .NotEmpty().WithMessage("Send message required MessageContent");
        }
    }
}
