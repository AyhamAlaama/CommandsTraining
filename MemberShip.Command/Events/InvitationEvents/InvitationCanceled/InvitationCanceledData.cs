namespace MemberShip.Command.Events.InvitationEvents.InvitationCanceled;
public record InvitationCanceledData(string AccountId, string SubscriptionId, string MemberId, string UserId);