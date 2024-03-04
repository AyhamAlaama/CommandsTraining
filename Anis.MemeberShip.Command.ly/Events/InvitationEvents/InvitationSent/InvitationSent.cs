using Anis.MemeberShip.Command.ly.StronglyTypedIDs;

namespace Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationSent;
public record InvitationSent(
       AggregateId AggregateId,
       int Sequence,
       string SubcriptionId,
        string MemberId,
       InvitationSentData Data,
       string UserId,
       int Version,
       DateTime DateTime
   ) :
    Event<InvitationSentData>
    (AggregateId, Sequence, SubcriptionId, MemberId, Data, UserId, Version, DateTime);

