namespace Anis.MemeberShip.Command.ly.Infrastructure.Persistence;

public class OutboxMessage
{

    private OutboxMessage(int id)
    {
        Id = id;
    }

    public OutboxMessage(Event @event)
    {
        Event = @event;
    }

    public int Id { get; private set; }
    public Event? Event { get; private set; }
}
