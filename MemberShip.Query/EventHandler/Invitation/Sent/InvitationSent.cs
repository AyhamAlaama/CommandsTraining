using MemberShip.Query.EventHandler;

namespace MemberShip.Query.EventHandler.Invitation.Sent
{
    public record InvitationSent(
       string AggregateId,
       int Sequence,
       InvitationSentData Data,
       DateTime DateTime,
       string UserId,
       int Version

   ) :
    Event<InvitationSentData>
    (AggregateId, Sequence, Data, DateTime, UserId, Version);
}
