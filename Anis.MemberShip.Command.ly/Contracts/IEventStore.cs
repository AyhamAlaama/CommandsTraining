using Anis.MemeberShip.Command.ly.StronglyTypedIDs;

namespace Anis.MemeberShip.Command.ly.Contracts;
public interface IEventStore
    {
        Task<List<Event>> GetAllAsync(AggregateId aggregateId,CancellationToken cancellationToken);
        Task CommitAsync(MemberShipDomain memberShip, CancellationToken cancellationToken);


}
