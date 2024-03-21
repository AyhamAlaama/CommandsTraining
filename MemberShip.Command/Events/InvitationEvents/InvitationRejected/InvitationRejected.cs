using MemberShip.Command.Events.InvitationEvents.InvitationSent;
using MemberShip.Command.StronglyTypedIDs;
using MemberShip.Command.Events;

namespace MemberShip.Command.Events.InvitationEvents.InvitationRejected;
public record InvitationRejected(
      AggregateId AggregateId,
       int Sequence,

       InvitationRejectedData Data,
       string UserId,
       int Version,
       DateTime DateTime
   ) : Event<InvitationRejectedData>
    (AggregateId, Sequence, Data, UserId, Version, DateTime);