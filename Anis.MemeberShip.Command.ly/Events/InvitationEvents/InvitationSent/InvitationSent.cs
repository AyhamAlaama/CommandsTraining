using Anis.MemeberShip.Command.ly.StronglyTypedIDs;

namespace Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationSent;
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

