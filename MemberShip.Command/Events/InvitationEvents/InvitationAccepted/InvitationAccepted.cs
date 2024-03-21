using MemberShip.Command.Events;
using MemberShip.Command.StronglyTypedIDs;

namespace MemberShip.Command.Events.InvitationEvents.InvitationAccepted;
public record InvitationAccepted(
      AggregateId AggregateId,
       int Sequence,

       InvitationAcceptedData Data,
       string UserId,
       int Version,
       DateTime DateTime
   ) : Event<InvitationAcceptedData>(AggregateId, Sequence, Data, UserId, Version, DateTime);


