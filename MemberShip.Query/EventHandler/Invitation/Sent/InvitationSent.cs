namespace Anis.MemberShip.Query.ly.EventHandler.Invitation.Sent
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
    (AggregateId, Sequence, Data, DateTime, UserId, Version );
}
