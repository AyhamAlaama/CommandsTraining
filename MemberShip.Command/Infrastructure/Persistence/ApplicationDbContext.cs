using MemberShip.Command.Events;
using MemberShip.Command.Events.InvitationEvents.InvitationAccepted;
using MemberShip.Command.Events.InvitationEvents.InvitationCanceled;
using MemberShip.Command.Events.InvitationEvents.InvitationRejected;
using MemberShip.Command.Events.InvitationEvents.InvitationSent;
using MemberShip.Command.Infrastructure.Persistence.Configurations;

namespace MemberShip.Command.Infrastructure.Persistence;
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

