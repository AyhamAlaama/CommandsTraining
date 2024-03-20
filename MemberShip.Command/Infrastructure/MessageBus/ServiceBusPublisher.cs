using Anis.MemeberShip.Command.ly.Infrastructure.Persistence;
using Azure.Messaging.ServiceBus;
using System.Text.Json;
using System.Text;
using Anis.MemeberShip.Command.ly.Extensions;
using Anis.MemeberShip.Command.ly.Extensions.OutboxMessagesExtensions;
using Anis.MemberShip.Command.ly.Infrastructure.MessageBus;

namespace Anis.MemeberShip.Command.ly.Infrastructure.MessageBus;

public class ServiceBusPublisher
{
    private readonly ServiceBusSender _sender;
    private readonly IServiceProvider _provider;
    private readonly object _lockObject = new();

    public ServiceBusPublisher(ServiceBusClient client, IServiceProvider provider)
    {
        _sender = client.CreateSender("anis-membership-ayham");
        _provider = provider;
    }

    private bool IsBusy { get; set; }

    public void StartPublishing()
    {
        Task.Run(() =>
        {
            try
            {
                if (IsBusy) return;

                IsBusy = true;
                lock (_lockObject)
                {
                    PublishEvents().GetAwaiter().GetResult();
                }
            }
            finally
            {
                IsBusy = false;
            }
        });
    }

    private async Task PublishEvents()
    {
        while (true)
        {
            using var scope = _provider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var messages = await dbContext.OutboxMessages
                .Include(x => x.Event)
                .OrderBy(x => x.Id)
                .Take(100)
                .ToListAsync();

            if (messages.Count == 0) return;

            foreach (var message in messages)
            {
                if (message.Event is null)
                    throw new InvalidOperationException("Event is null, please include the event in the query");
                   
                var serviceBusMessage = message.Event.ToMessage();

                await _sender.SendMessageAsync(serviceBusMessage);

                dbContext.OutboxMessages.Remove(message);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}


