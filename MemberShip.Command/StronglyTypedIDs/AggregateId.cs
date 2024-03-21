namespace MemberShip.Command.StronglyTypedIDs;
public readonly record struct AggregateId(SubscrptionId SubscrptionId, MemberId MemberId)
{
    // just for printing and returned values for response
    public override string ToString() =>
                            SubscrptionId.subscrptionId
                            + "/" +
                            MemberId.memberId;
}
