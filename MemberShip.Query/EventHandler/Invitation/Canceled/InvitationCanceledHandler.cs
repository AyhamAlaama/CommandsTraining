using MediatR;
using MemberShip.Query.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MemberShip.Query.EventHandler.Invitation.Canceled
{
    public class InvitationCanceledHandler : IRequestHandler<InvitationCanceled, bool>
    {
        // app db context
        private readonly ApplicationDbContext _context;

        public InvitationCanceledHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(InvitationCanceled @event, CancellationToken cancellationToken)
        {
            var memberShip = await _context.MemberShips.FindAsync(@event.AggregateId);

            if (memberShip is null)return false;
            

            if (@event.Sequence <= memberShip.Sequence) return true;

            if (@event.Sequence > memberShip.Sequence + 1) return false;

            memberShip.InvitationCanceled(@event);

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
