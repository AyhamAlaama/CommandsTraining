using Azure.Messaging.ServiceBus;
using MediatR;
using System.Text.Json;
using System.Text;
using MemberShip.Query.EventHandler.Invitation.Sent;
using MemberShip.Query.Infrastructure.Helpers;
using MemberShip.Query.EventHandler;

namespace MemberShip.Query.Infrastructure.ServiceBus.MemberShip
{
    public class MemberShipListener : IHostedService
    {
        private readonly ServiceBusSessionProcessor _processor;
        private readonly ILogger<MemberShipListener> _logger;
        private readonly IServiceProvider _serviceProvider;


        public MemberShipListener(MemberShipServiceBus serviceBus,
            IConfiguration configuration,
            ILogger<MemberShipListener> logger,
            IServiceProvider serviceProvider)
        {
            var options = configuration.GetSection(ServiceBusConfig.ServiceBus).Get<ServiceBusConfig>();
            _logger = logger;
            _serviceProvider = serviceProvider;
            _processor = serviceBus.Client().CreateSessionProcessor(
                topicName: options?.Topic,
                subscriptionName: options?.Subscription,
                options: new ServiceBusSessionProcessorOptions()
                {
                    AutoCompleteMessages = false,
                    PrefetchCount = 1,
                    MaxConcurrentSessions = 100,
                    MaxConcurrentCallsPerSession = 1
                });

            _processor.ProcessMessageAsync += Processor_ProcessMessageAsync;
            _processor.ProcessErrorAsync += Processor_ProcessErrorAsync;



        }



        private async Task Processor_ProcessMessageAsync(ProcessSessionMessageEventArgs arg)
        {
            var json = Encoding.UTF8.GetString(arg.Message.Body);

            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var isHandled = arg.Message.Subject switch
            {
                nameof(InvitationSent) => await mediator.Send(Deserialize<InvitationSent>(json)),
                _ => await mediator.Send(Deserialize<UnknownEvent>(json)),
            };

            if (isHandled)
            {
                await arg.CompleteMessageAsync(arg.Message);
            }
            else
            {
                _logger.LogWarning("Message {MessageId} not handled", arg.Message.MessageId);
                await Task.Delay(5000);
                await arg.AbandonMessageAsync(arg.Message);
            }
        }



        private static T Deserialize<T>(string json)
        => JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
        ?? throw new InvalidOperationException("Failed to deserialize message");

        private Task Processor_ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            _logger.LogCritical(arg.Exception, "Message handler encountered an exception," +
                " Error Source:{ErrorSource}," +
                " Entity Path:{EntityPath}",
                arg.ErrorSource.ToString(),
                arg.EntityPath
            );

            return Task.CompletedTask;
        }

        public Task StartAsync(CancellationToken cancellationToken) => _processor.StartProcessingAsync(cancellationToken);

        public Task StopAsync(CancellationToken cancellationToken) => _processor.CloseAsync(cancellationToken);
    }
}
