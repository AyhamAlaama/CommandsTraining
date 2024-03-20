using Anis.MemeberShip.Command.ly.Events;
using Anis.MemeberShip.Command.ly.StronglyTypedIDs;

namespace Anis.MemeberShip.Command.ly.Contracts;
public interface IAggregate
    {
         AggregateId Id { get; }
         int Sequence { get; }
        IReadOnlyList<Event> GetUncommittedEvents();
        void MarkChangesAsCommitted();
    }

