using MemberShip.Command.Events;
using MemberShip.Command.StronglyTypedIDs;

namespace MemberShip.Command.Contracts;
public interface IEventStore
{
    Task<List<Event>> GetAllAsync(AggregateId aggregateId, CancellationToken cancellationToken);
    Task CommitAsync(MemberShipDomain memberShip, CancellationToken cancellationToken);


}
