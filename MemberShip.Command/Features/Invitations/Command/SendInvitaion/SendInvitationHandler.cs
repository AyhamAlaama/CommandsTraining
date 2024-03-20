using Anis.MemeberShip.Command.ly.Const;
using Anis.MemeberShip.Command.ly.Contracts;
using Anis.MemeberShip.Command.ly.StronglyTypedIDs;
using Anis.MemeberShip.Command.ly.v1;


namespace Anis.MemeberShip.Command.ly.Features.Invitations.Command.SendInvitaion;
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
            var memberShip = Domain.MemberShip.AddToSubscription(request);
            await _eventStore.CommitAsync(memberShip, cancellationToken);
            return new InvitationResponse { Id = memberShip.Id.ToString(), Message = Constants.Sent };
        }
        else
        {
            var memberShip = Domain.MemberShip.LoadFromHistory(events);
            memberShip.SendNewInvitation(request);
            await _eventStore.CommitAsync(memberShip, cancellationToken);
            return new InvitationResponse { Id = memberShip.Id.ToString(), Message = Constants.Sent };

        }


    }
}
