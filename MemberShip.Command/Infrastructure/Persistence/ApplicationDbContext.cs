using Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationAccepted;
using Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationCanceled;
using Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationRejected;
using Anis.MemeberShip.Command.ly.Events.InvitationEvents.InvitationSent;
using Anis.MemeberShip.Command.ly.Infrastructure.Persistence.Configurations;

namespace Anis.MemeberShip.Command.ly.Infrastructure.Persistence;
    public class ApplicationDbContext:DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }
       public DbSet<Event> Events { get; set; }
       public DbSet<OutboxMessage> OutboxMessages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfiguration(new BaseEventConfigurations());
        modelBuilder.ApplyConfiguration(new GenericEventConfiguration<InvitationSent, InvitationSentData>());
        modelBuilder.ApplyConfiguration(new GenericEventConfiguration<InvitationCanceled, InvitationCanceledData>());
        modelBuilder.ApplyConfiguration(new GenericEventConfiguration<InvitationAccepted, InvitationAcceptedData>());
        modelBuilder.ApplyConfiguration(new GenericEventConfiguration<InvitationRejected, InvitationRejectedData>());
        base.OnModelCreating(modelBuilder);
    }
}

