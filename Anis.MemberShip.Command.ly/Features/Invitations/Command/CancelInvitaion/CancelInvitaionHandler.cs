using Anis.MemeberShip.Command.ly.Const;
using Anis.MemeberShip.Command.ly.Exceptions;
using Anis.MemeberShip.Command.ly.Infrastructure.Implementation;
using Anis.MemeberShip.Command.ly.StronglyTypedIDs;
using Anis.MemeberShip.Command.ly.v1;


namespace Anis.MemeberShip.Command.ly.Features.Invitations.Command.CancelInvitaion;
public class CancelInvitaionHandler : IRequestHandler<CancelInvitaionCommand, InvitationResponse>
{
    private readonly IEventStore _eventStore;

    public CancelInvitaionHandler(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public async Task<InvitationResponse> Handle(CancelInvitaionCommand request, CancellationToken cancellationToken)
    {
        var aggregateId = new AggregateId(
                                (SubscrptionId)request.SubscrptionId,
                                (MemberId)request.MemberId);
        var events = await _eventStore.GetAllAsync(aggregateId, cancellationToken);

        if (events.Count == 0)
            throw new NotFoundException("Subscription not found");

        var memberShip = Domain.MemberShip.LoadFromHistory(events);

        memberShip.CancelInvitation(request);

        await _eventStore.CommitAsync(memberShip, cancellationToken);

        return new InvitationResponse { Id = events[0].AggregateId.ToString(),Message=Constants.Canceled };
    }
}
