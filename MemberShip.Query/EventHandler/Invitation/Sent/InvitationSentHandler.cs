using MediatR;
using MemberShip.Query.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace MemberShip.Query.EventHandler.Invitation.Sent
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
            var memberShip = await _context.MemberShips.FindAsync(@event.AggregateId);

            if (memberShip is null)
                await _context.MemberShips.AddAsync(MemberShipEntity.FromSentEvent(@event), cancellationToken);
            else
                memberShip.NewInvitationSent(@event);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
