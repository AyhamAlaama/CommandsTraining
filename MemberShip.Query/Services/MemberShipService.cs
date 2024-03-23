using Grpc.Core;
using MediatR;
using MemberShip.Query.Extensions;
using MemberShip.Query.Infrastructure.Persistence;
using MemberShip.Query.v1;
using Microsoft.EntityFrameworkCore;
using Member = MemberShip.Query.v1.MemberShip;

namespace MemberShip.Query.Services
{
    public class MemberShipService : Member.MemberShipBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MemberShipService> _logger;
        private readonly IMediator _mediator;
        public MemberShipService(ILogger<MemberShipService> logger, ApplicationDbContext context, IMediator mediator)
        {
            _logger = logger;
            _context = context;
            _mediator = mediator;
        }
        public override async Task<v1.FilterResponse> Filter(v1.FilterRequest request, ServerCallContext context)
        {
            var query = request.ToQuery();
            var result = await _mediator.Send(query, context.CancellationToken);
            var memberShips = result.memberShipEntity.Select(m=> m.ToFilterOutput());
            return new FilterResponse() { Membershiplist = { memberShips } };
        }


    }
}