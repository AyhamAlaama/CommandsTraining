namespace Anis.MemeberShip.Command.ly.Extensions.OutboxMessagesExtensions;
public static class Extensions
{
    public static EventMessage ToEventMessage(this Event @event)
    {
        return new EventMessage(
            Id: @event.Id,
            SubscrptionId: @event.AggregateId.SubscrptionId.subscrptionId,
            MemberId: @event.AggregateId.MemberId.memberId,
            Sequence: @event.Sequence,
            UserId: @event.UserId,
            DateTime: @event.DateTime,
            Version: @event.Version

            );
    }
}
public record EventMessage
(
    int Id,
    string SubscrptionId,
    string MemberId,
    int Sequence,
    string UserId,
    int Version,
    DateTime DateTime
);
