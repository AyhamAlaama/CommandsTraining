using MemberShip.Command.v1;

namespace MemberShip.Command.Features.Invitations.Command.RejectInvitaion;

public class RejectInvitaionCommand : IRequest<InvitationResponse>
{
    public required string AccountId { get; init; }
    public required string SubscrptionId { get; init; }
    public required string MemberId { get; init; }
    public required string UserId { get; init; }
}
