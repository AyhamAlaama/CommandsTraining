﻿
using Anis.MemeberShip.Command.ly.Infrastructure.MessageBus;
using Anis.MemeberShip.Command.ly.Infrastructure.Persistence;
using Anis.MemeberShip.Command.ly.StronglyTypedIDs;

namespace Anis.MemeberShip.Command.ly.Infrastructure.Implementation;

public class EventStore : IEventStore
    {
    public EventStore()
    {
        
    }
        private readonly ApplicationDbContext _context;

    public readonly ServiceBusPublisher _serviceBusPublisher;

    public EventStore(ApplicationDbContext context, ServiceBusPublisher serviceBusPublisher)
        {
                _context= context;
        _serviceBusPublisher = serviceBusPublisher;
    }

        public async Task CommitAsync(MemberShip memberShip, CancellationToken cancellationToken)
        {
            var events = memberShip.GetUncommittedEvents();
       

        await _context.Events.AddRangeAsync(memberShip.GetUncommittedEvents(), cancellationToken);
        var messages = events.Select(m => new OutboxMessage(m));
        await _context.OutboxMessages.AddRangeAsync(messages, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        _serviceBusPublisher.StartPublishing();

    }
    public Task<List<Event>> GetAllAsync(
            AggregateId aggregateId,
            CancellationToken cancellationToken) =>
                _context.Events
                    .Where(x => x.AggregateId == aggregateId)
                    .OrderBy(x => x.Id)
                    .ToListAsync(cancellationToken);


}
