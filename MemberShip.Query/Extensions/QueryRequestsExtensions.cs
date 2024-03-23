using MemberShip.Query.QueryHandlers;
using MemberShip.Query.v1;

namespace MemberShip.Query.Extensions
{
    public static class QueryRequestsExtensions
    {
        public static FilterQuery ToQuery(this FilterRequest request) => new(UserId:request.Id);
    }
}
