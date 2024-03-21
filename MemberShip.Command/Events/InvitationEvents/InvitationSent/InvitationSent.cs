using MemberShip.Command.StronglyTypedIDs;
using MemberShip.Command.Events;

namespace MemberShip.Command.Events.InvitationEvents.InvitationSent;
public record InvitationSent(
       AggregateId AggregateId,
       int Sequence,

       InvitationSentData Data,
       string UserId,
       int Version,
       DateTime DateTime
   ) :
    Event<InvitationSentData>
    (AggregateId, Sequence, Data, UserId, Version, DateTime);

