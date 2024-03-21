using MemberShip.Command.StronglyTypedIDs;

namespace MemberShip.Command.Infrastructure.MessageBus;

public class MessageBody
{
    public required string AggregateId { get; init; }
    public required DateTime DateTime { get; init; }
    public required int Sequence { get; init; }
    public required string Type { get; init; }
    public required string UserId { get; init; }
    public required int Version { get; init; }
    public required object Data { get; init; }
}
