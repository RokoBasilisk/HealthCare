using FluentValidation;

namespace OperationService.Event.EventValidators
{
    public class JoinRoomEventValidator : AbstractValidator<JoinRoomEvent> 
    {
        public JoinRoomEventValidator()
        {
            RuleFor(e => e.RoomId)
                .NotEmpty().WithMessage("Join room action required RoomId");
        }
    }
}
