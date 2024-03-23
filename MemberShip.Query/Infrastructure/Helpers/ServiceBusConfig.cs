namespace MemberShip.Query.Infrastructure.Helpers;

public class ServiceBusConfig
{

    public const string ServiceBus = "ServiceBusConfigurations";
    public string? SBConnectionString { get; set; }
    public string? Topic { get; set; }
    public string? Subscription { get; set; }
}
