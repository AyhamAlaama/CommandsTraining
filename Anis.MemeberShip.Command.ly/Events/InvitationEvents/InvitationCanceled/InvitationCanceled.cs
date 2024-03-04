using Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationRejected;
using Anis.MemeberShip.Command.ly.StronglyTypedIDs;

namespace Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationCanceled;
public record InvitationCanceled(
       AggregateId AggregateId,
       int Sequence,
       string SubcriptionId,
        string MemberId,
       InvitationCanceledData Data,
       string UserId,
       int Version,
       DateTime DateTime
   ) : Event<InvitationCanceledData>
    (AggregateId, Sequence, SubcriptionId, MemberId, Data, UserId, Version, DateTime);



    