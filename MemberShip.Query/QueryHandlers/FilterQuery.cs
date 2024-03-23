using MediatR;
namespace MemberShip.Query.QueryHandlers;
    public record FilterQuery(string? UserId) : IRequest<FilterResult> { }

