namespace MemberShip.Command.Events.InvitationEvents.InvitationAccepted;
public record InvitationAcceptedData(string AccountId, string SubscriptionId, string MemberId, string UserId);