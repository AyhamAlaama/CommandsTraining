using Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationRejected;
using Anis.MemeberShip.Command.ly.StronglyTypedIDs;

namespace Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationCanceled;
public record InvitationCanceled(
       AggregateId AggregateId,
       int Sequence,

       InvitationCanceledData Data,
       string UserId,
       int Version,
       DateTime DateTime
   ) : Event<InvitationCanceledData>
    (AggregateId, Sequence, Data, UserId, Version, DateTime);



    