
using Grpc.Core;
using Member = Anis.MemberShip.Query.ly.v1.MemberShip;

namespace Anis.MemberShip.Query.ly.Services
{
    public class MemberShipService : Member.MemberShipBase
    {
        private readonly ILogger<MemberShipService> _logger;
        public MemberShipService(ILogger<MemberShipService> logger)
        {
            _logger = logger;
        }
        public override Task<v1.FilterResponse> Filter(v1.FilterRequest request, ServerCallContext context)
        {
            return base.Filter(request, context);
        }


    }
}