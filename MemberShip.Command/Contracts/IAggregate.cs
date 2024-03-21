using MemberShip.Command.Events;
using MemberShip.Command.StronglyTypedIDs;

namespace MemberShip.Command.Contracts;
public interface IAggregate
{
    AggregateId Id { get; }
    int Sequence { get; }
    IReadOnlyList<Event> GetUncommittedEvents();
    void MarkChangesAsCommitted();
}

