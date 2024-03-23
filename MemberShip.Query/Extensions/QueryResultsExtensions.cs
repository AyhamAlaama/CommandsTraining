using MemberShip.Query.v1;

namespace MemberShip.Query.Extensions
{
    public static class QueryResultsExtensions
    {
        public static MemberShipOutput ToFilterOutput(this MemberShipEntity entity) => new()
        {
            AccountId = entity.AccountId,
            InviteStatus = entity.InviteStatus,
            MemberId = entity.MemberId,
            SubscrptionId = entity.SubscriptionId,
            UserId = entity.UserId
        } ;
    }
}
