using MediatR;
using MemberShip.Query.Infrastructure.Persistence;


namespace MemberShip.Query.QueryHandlers
{
    public class FilterQueryHandler : IRequestHandler<FilterQuery, FilterResult>
    {
        private readonly ApplicationDbContext _context;

        public FilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }


        public Task<FilterResult> Handle(FilterQuery request, CancellationToken cancellationToken)
        {
            
            return FilterAsync(request, cancellationToken);
        }
        private async Task<FilterResult> FilterAsync(FilterQuery filter, CancellationToken cancellationToken)
        {
            var query = _context.MemberShips.AsQueryable();
            
            return new FilterResult(
                memberShipEntity: query.Where(t => t.UserId == filter.UserId).ToList()
            ) ;

        }


    }
}
