using Anis.MemberShip.Query.ly.Infrastructre.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Anis.MemberShip.Query.ly.EventHandler.Invitation.Sent
{
    public class InvitationSentHandler : IRequestHandler<InvitationSent, bool>
    {
        // app db context
        private readonly ApplicationDbContext _context;

        public InvitationSentHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(InvitationSent @event, CancellationToken cancellationToken)
        {
            if (await _context.MemberShips.AnyAsync(e => e.Id == @event.AggregateId, cancellationToken))
                return true;
            await _context.MemberShips.AddAsync(MemberShipEntity.FromSentEvent(@event), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
