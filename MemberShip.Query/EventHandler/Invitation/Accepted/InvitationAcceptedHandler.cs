using MediatR;
using MemberShip.Query.Infrastructure.Persistence;

namespace MemberShip.Query.EventHandler.Invitation.Accepted;
public class InvitationAcceptedHandler : IRequestHandler<InvitationAccepted, bool>
{
    // app db context
    private readonly ApplicationDbContext _context;

    public InvitationAcceptedHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(InvitationAccepted @event, CancellationToken cancellationToken)
    {
        var memberShip = await _context.MemberShips.FindAsync(@event.AggregateId);

        if (memberShip is null) return false;


        if (@event.Sequence <= memberShip.Sequence) return true;

        if (@event.Sequence > memberShip.Sequence + 1) return false;

        memberShip.InvitationAccepted();

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}