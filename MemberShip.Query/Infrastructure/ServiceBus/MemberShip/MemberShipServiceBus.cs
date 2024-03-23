using Azure.Messaging.ServiceBus;
using MemberShip.Query.Infrastructure.Helpers;
using Microsoft.Extensions.Options;

namespace MemberShip.Query.Infrastructure.ServiceBus.MemberShip;

public class MemberShipServiceBus
{
    private readonly ServiceBusConfig _config;
    public MemberShipServiceBus(IOptions<ServiceBusConfig> config)
    => _config = config.Value;
    public ServiceBusClient Client() => new ServiceBusClient
        (_config.SBConnectionString);
}
