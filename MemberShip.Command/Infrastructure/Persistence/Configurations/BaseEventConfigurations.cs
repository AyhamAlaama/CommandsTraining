using Anis.MemeberShip.Command.ly.StronglyTypedIDs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Anis.MemeberShip.Command.ly.Infrastructure.Persistence.Configurations;

public class BaseEventConfigurations : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasIndex(e => new { e.AggregateId, e.Sequence }).IsUnique();
        builder.Property<string>("EventType").HasMaxLength(128);
        builder.HasDiscriminator<string>("EventType");

  

        var converter = new ValueConverter<AggregateId, string>(
                            id => id.SubscrptionId.subscrptionId
                                  + "/"+
                                  id.MemberId.memberId,
                            aggregateid => 
                            new AggregateId(
                               (SubscrptionId) aggregateid.Split("/",StringSplitOptions.None)[0],
                               (MemberId)      aggregateid.Split("/", StringSplitOptions.None)[1])
                            );


        builder.Property(e => e.AggregateId)
            .HasConversion(converter);
    }
}
