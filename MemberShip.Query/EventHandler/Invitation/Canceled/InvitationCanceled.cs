namespace MemberShip.Query.EventHandler.Invitation.Canceled;

public record InvitationCanceled(
   string AggregateId,
   int Sequence,
   object Data,
   DateTime DateTime,
   string UserId,
   int Version

) :
Event<object>
(AggregateId, Sequence, Data, DateTime, UserId, Version);
