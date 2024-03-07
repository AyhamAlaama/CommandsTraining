
using Anis.MemeberShip.Command.ly.StronglyTypedIDs;

namespace Anis.MemeberShip.Command.ly.Events;

    public abstract record Event(
        int Id,
        AggregateId AggregateId,
        int Sequence,
        string UserId,
        int Version,
        DateTime DateTime
    )
    {
        public string Type => GetType().Name;
  }

    public abstract record Event<T>(
        AggregateId AggregateId,
        int Sequence,
        T Data,
        string UserId,
        int Version,
        DateTime DateTime
    ) : Event(Id: default, AggregateId, Sequence, UserId, Version, DateTime);
