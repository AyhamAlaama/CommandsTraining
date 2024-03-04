using Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationSent;
using Anis.MemeberShip.Command.ly.StronglyTypedIDs;

namespace Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationRejected;
public record InvitationRejected(
      AggregateId AggregateId,
       int Sequence,
       string SubcriptionId,
        string MemberId,
       InvitationRejectedData Data,
       string UserId,
       int Version,
       DateTime DateTime
   ) : Event<InvitationRejectedData>
    (AggregateId, Sequence, SubcriptionId, MemberId, Data, UserId, Version, DateTime);