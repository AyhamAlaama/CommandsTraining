namespace MemberShip.Query.EventHandler.Invitation.Sent;
public record InvitationSentData(
    string AccountId,
    string SubscriptionId,
    string MemberId,
    string UserId);