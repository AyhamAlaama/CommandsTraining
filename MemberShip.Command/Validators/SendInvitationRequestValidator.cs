using MemberShip.Command.v1;
using FluentValidation;

namespace MemberShip.Command.Validators
{
    public class SendInvitationRequestValidator : AbstractValidator<SendInvitationRequest>
    {
        public SendInvitationRequestValidator()
        {
            RuleFor(x => x.SubscrptionId).NotEmpty().Must(n => !n.Contains('/')).WithMessage("Please Dont Insert / in it");
            RuleFor(x => x.AccountId).NotEmpty();
            RuleFor(x => x.MemberId).NotEmpty().Must(n => !n.Contains('/')).WithMessage("Please Dont Insert / in it");
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
