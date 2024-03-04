
using Anis.MemeberShip.Command.ly.Domain;
using Anis.MemeberShip.Command.ly.Events;
using Anis.MemeberShip.Command.ly.Infrastructure.Persistence;
using Anis.MemeberShip.Command.ly.StronglyTypedIDs;
using Microsoft.EntityFrameworkCore;

namespace Anis.MemeberShip.Command.ly.Infrastructure.Implementation;

    public class EventStore : IEventStore
    {
        private readonly ApplicationDbContext _context;
        public EventStore(ApplicationDbContext context)
        {
                _context= context;
        }

        public async Task CommitAsync(MemberShip memberShip, CancellationToken cancellationToken)
        {
            await _context.Events.AddRangeAsync(memberShip.GetUncommittedEvents(), cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }
        public Task<List<Event>> GetAllAsync(
            AggregateId aggregateId,
            CancellationToken cancellationToken) =>
                _context.Events
                    .Where(x => x.AggregateId == aggregateId)
                    .OrderBy(x => x.Id)
                    .ToListAsync(cancellationToken);


}

