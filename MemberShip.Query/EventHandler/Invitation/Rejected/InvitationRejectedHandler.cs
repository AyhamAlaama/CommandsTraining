using MediatR;
using MemberShip.Query.EventHandler.Invitation.Accepted;
using MemberShip.Query.Infrastructure.Persistence;

namespace MemberShip.Query.EventHandler.Invitation.Rejected;
public class InvitationRejectedHandler : IRequestHandler<InvitationRejected, bool>
{
    // app db context
    private readonly ApplicationDbContext _context;

    public InvitationRejectedHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(InvitationRejected @event, CancellationToken cancellationToken)
    {
        var memberShip = await _context.MemberShips.FindAsync(@event.AggregateId);

        if (memberShip is null) return false;


        if (@event.Sequence <= memberShip.Sequence) return true;

        if (@event.Sequence > memberShip.Sequence + 1) return false;

        memberShip.InvitationRejected();

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}