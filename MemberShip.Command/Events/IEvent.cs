using MemberShip.Command.StronglyTypedIDs;

namespace MemberShip.Command.Events;

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
