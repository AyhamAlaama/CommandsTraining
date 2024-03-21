using MemberShip.Command.Events;
using MemberShip.Command.StronglyTypedIDs;

namespace MemberShip.Command.Events.InvitationEvents.InvitationCanceled;
public record InvitationCanceled(
       AggregateId AggregateId,
       int Sequence,

       InvitationCanceledData Data,
       string UserId,
       int Version,
       DateTime DateTime
   ) : Event<InvitationCanceledData>
    (AggregateId, Sequence, Data, UserId, Version, DateTime);



