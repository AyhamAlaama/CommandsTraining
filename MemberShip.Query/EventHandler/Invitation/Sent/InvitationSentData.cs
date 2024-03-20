namespace Anis.MemberShip.Query.ly.EventHandler.Invitation.Sent;
public record InvitationSentData(
    string AccountId, 
    string SubscriptionId, 
    string MemberId, 
    string UserId);