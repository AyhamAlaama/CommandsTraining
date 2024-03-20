namespace Anis.MemeberShip.Command.ly.StronglyTypedIDs;

public readonly record struct SubscrptionId(string subscrptionId)
{

    // just make it Hard Casting for keep Attenation about value
    public static explicit operator SubscrptionId(string value)
    {
        return new(value);
    }

}
