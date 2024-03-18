using MediatR;
namespace Anis.MemberShip.Query.ly.EventHandler;

    public record Event<T>(
       string AggregateId,
       int Sequence,
       T Data,
       DateTime DateTime,
       string UserId,
       int Version
   ) : IRequest<bool>;

