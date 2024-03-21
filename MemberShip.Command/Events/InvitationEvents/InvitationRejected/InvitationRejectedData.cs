namespace MemberShip.Command.Events.InvitationEvents.InvitationRejected;
public record InvitationRejectedData(string AccountId, string SubscriptionId, string MemberId, string UserId);