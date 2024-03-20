using Anis.MemeberShip.Command.ly.StronglyTypedIDs;

namespace Anis.MemberShip.Command.ly.Events;

public interface IEvent
{
    AggregateId AggregateId { get; }
    int Sequence { get; }
    DateTime DateTime { get; }
    string UserId { get; }
    int Version { get; }
    string Type { get; }
    dynamic Data { get; }
}
