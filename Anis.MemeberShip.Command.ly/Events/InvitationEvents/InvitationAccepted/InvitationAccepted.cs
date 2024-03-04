using Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationCanceled;
using Anis.MemeberShip.Command.ly.StronglyTypedIDs;

namespace Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationAccepted;
public record InvitationAccepted(
      AggregateId AggregateId,
       int Sequence,
       string SubcriptionId,
        string MemberId,
       InvitationAcceptedData Data,
       string UserId,
       int Version,
       DateTime DateTime
   ) : Event<InvitationAcceptedData>(AggregateId, Sequence, SubcriptionId, MemberId, Data, UserId, Version, DateTime);


