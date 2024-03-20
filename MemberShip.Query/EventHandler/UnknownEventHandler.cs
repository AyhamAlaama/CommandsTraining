using Anis.MemberShip.Query.ly.Infrastructre.Persistence;
using MediatR;

namespace Anis.MemberShip.Query.ly.EventHandler
{
    public class UnknownEventHandler : IRequestHandler<UnknownEvent, bool>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UnknownEventHandler> _logger;
        public UnknownEventHandler(ApplicationDbContext context, ILogger<UnknownEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Handle(UnknownEvent @event, CancellationToken cancellationToken)
        {
            var memberShips = await _context.MemberShips.FindAsync(@event.AggregateId);
            if (memberShips is null)
            {
                _logger.LogWarning("MemberShip {MemberShipId} not found", @event.AggregateId);
                return false;
            }
            if (@event.Sequence <= memberShips.Sequence) return true;
            if (@event.Sequence > memberShips.Sequence + 1)
            {
                _logger.LogWarning("Sequence {Sequence} is not expected for MemberShip {MemberShipsId}", @event.Sequence, @event.AggregateId);
                return false;
            }
            memberShips.IncrementSequence();
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
