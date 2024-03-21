using MemberShip.Command.Constants;
using MemberShip.Command.Contracts;
using MemberShip.Command.StronglyTypedIDs;
using MemberShip.Command.v1;
using MemberShip.Command.Contracts;


namespace MemberShip.Command.Features.Invitations.Command.SendInvitaion;
public class SendInvitationCommandHandler :
    IRequestHandler<SendInvitationCommand, InvitationResponse>
{
    private readonly IEventStore _eventStore;

    public SendInvitationCommandHandler(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public async Task<InvitationResponse> Handle(SendInvitationCommand request, CancellationToken cancellationToken)
    {
        var aggregateId = new AggregateId(
                                (SubscrptionId)request.SubscrptionId,
                                (MemberId)request.MemberId);

        var events = await _eventStore.GetAllAsync(aggregateId, cancellationToken);

        if (events.Count == 0)
        {
            var memberShip = MemberShipDomain.AddToSubscription(request);
            await _eventStore.CommitAsync(memberShip, cancellationToken);
            return new InvitationResponse { Id = memberShip.Id.ToString(), Message = ResponseConstants.Sent };
        }
        else
        {
            var memberShip = MemberShipDomain.LoadFromHistory(events);
            memberShip.SendNewInvitation(request);
            await _eventStore.CommitAsync(memberShip, cancellationToken);
            return new InvitationResponse { Id = memberShip.Id.ToString(), Message = ResponseConstants.Sent };

        }


    }
}
