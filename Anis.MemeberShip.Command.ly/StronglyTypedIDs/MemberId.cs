namespace Anis.MemeberShip.Command.ly.StronglyTypedIDs;

public readonly record struct MemberId(string memberId)
{
    
        // just make it Hard Casting for keep Attenation about value


    public static explicit operator MemberId(string value)
    {
        return new(value);
    }

}
