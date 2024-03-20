using Anis.MemberShip.Query.ly.Infrastructure.Helpers;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;

namespace Anis.MemberShip.Query.ly.Infrastructre.ServiceBus.MemberShip;

public class MemberShipServiceBus
{
    private readonly ServiceBusConfig _config;
    public MemberShipServiceBus(IOptions<ServiceBusConfig> config)
    => _config = config.Value;
    public ServiceBusClient Client() => new ServiceBusClient
        (_config.SBConnectionString);
}
