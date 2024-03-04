namespace Anis.MemeberShip.Command.ly.StronglyTypedIDs;
public readonly record struct AggregateId(SubscrptionId SubscrptionId, MemberId MemberId)
{
    // just for printing and returned values for response
    public override string ToString()=>
                            SubscrptionId.subscrptionId.Replace("/","")
                            +"/"+
                            MemberId.memberId.Replace("/", "");
}
public readonly record struct SubscrptionId(string subscrptionId)
{

    // just make it Hard Casting for keep Attenation about value
    public static explicit operator SubscrptionId(string value)
    {
        return new(value);
    }
    
}

public readonly record struct MemberId(string memberId)
{
    
        // just make it Hard Casting for keep Attenation about value


    public static explicit operator MemberId(string value)
    {
        return new(value);
    }
 
}
