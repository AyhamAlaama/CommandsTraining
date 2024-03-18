using Anis.MemberShip.Query.ly.EventHandler.Invitation.Sent;

namespace Anis.MemberShip.Query.ly.Entities;

public class MemberShip
{
    public string Id { get; private set; }
    public int Sequence { get; private set; }
    public string AccountId { get; private set; }
    public string? SubscriptionId { get; private set; }
    public string MemberId { get; private set; }
    public string UserId { get; private set; }
    public string InviteStatus { get; private set; }
    private MemberShip(
            string id,
            int sequence,
            string accountId,
            string subscriptionId,
            string memberId,
            string userId,
            string inviteStatus)
    {
        Id = id;
        Sequence = sequence;
        AccountId = accountId;
        SubscriptionId = subscriptionId;
        MemberId = memberId;
        UserId = userId;
        InviteStatus = inviteStatus;

    }

    public static MemberShip FromSentEvent(InvitationSent @event) => new
        (
        id:@event.AggregateId,
        sequence:@event.Sequence,
        accountId:@event.Data.AccountId,
        subscriptionId: @event.Data.SubscriptionId,
        memberId: @event.Data.MemberId,
        userId: @event.Data.UserId,
        inviteStatus:"P"
        );
    public void IncrementSequence() => Sequence++;
}
