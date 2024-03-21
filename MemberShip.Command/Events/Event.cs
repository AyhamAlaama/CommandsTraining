using MemberShip.Command.StronglyTypedIDs;

namespace MemberShip.Command.Events;

public abstract record Event(
    int Id,
    AggregateId AggregateId,
    int Sequence,
    string UserId,
    int Version,
    DateTime DateTime
) : IEvent
{
    public string Type => GetType().Name;

    dynamic IEvent.Data => ((dynamic)this).Data;
}

public abstract record Event<T>(
    AggregateId AggregateId,
    int Sequence,
    T Data,
    string UserId,
    int Version,
    DateTime DateTime
) : Event(Id: default, AggregateId, Sequence, UserId, Version, DateTime);
