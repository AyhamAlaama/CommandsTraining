using Azure.Messaging.ServiceBus;
using MemberShip.Command.Events;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MemberShip.Command.Infrastructure.MessageBus
{
    public static class ServiceBusExtensions
    {
        public static JsonSerializerOptions Options => new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        public static ServiceBusMessage ToMessage(this IEvent @event)
        {
            var body = new MessageBody()
            {
                AggregateId = @event.AggregateId.ToString(),
                DateTime = @event.DateTime,
                Sequence = @event.Sequence,
                Type = @event.Type.ToString(),
                UserId = @event.UserId,
                Version = @event.Version,
                Data = @event.Data
            };

            var messageBody = JsonSerializer.Serialize(body, Options);

            return new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody))
            {
                PartitionKey = @event.AggregateId.ToString(),
                SessionId = @event.AggregateId.ToString(),
                Subject = @event.Type.ToString(),
                ApplicationProperties = {
                    { nameof(@event.AggregateId), @event.AggregateId.ToString() },
                    { nameof(@event.Sequence), @event.Sequence },
                    { nameof(@event.Version), @event.Version },
                }
            };
        }
    }
}
