
using MemberShip.Command.Exceptions;
using MemberShip.Command.Constants;
using MemberShip.Command.StronglyTypedIDs;
using MemberShip.Command.v1;

namespace MemberShip.Command.Features.Invitations.Command.AcceptInvitaion;
public class AcceptInvitaionHandler : IRequestHandler<AcceptInvitaionCommand, InvitationResponse>
{
    private readonly IEventStore _eventStore;

    public AcceptInvitaionHandler(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }
    public async Task<InvitationResponse> Handle(AcceptInvitaionCommand request, CancellationToken cancellationToken)
    {
        var aggregateId = new AggregateId(
                                (SubscrptionId)request.SubscrptionId,
                                (MemberId)request.MemberId);
        var events = await _eventStore.GetAllAsync(aggregateId, cancellationToken);

        if (events.Count == 0)
            throw new NotFoundException("Subscription not found");

        var memberShip = MemberShipDomain.LoadFromHistory(events);

        memberShip.AcceptInvitation(request);

        await _eventStore.CommitAsync(memberShip, cancellationToken);

        return new InvitationResponse { Id = events[0].AggregateId.ToString(), Message = ResponseConstants.Accepted };
    }
}
