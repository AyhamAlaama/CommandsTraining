namespace MemberShip.Query.EventHandler.Invitation.Rejected;
public record InvitationRejected(
   string AggregateId,
   int Sequence,
   object Data,
   DateTime DateTime,
   string UserId,
   int Version

) :
Event<object>
(AggregateId, Sequence, Data, DateTime, UserId, Version);
