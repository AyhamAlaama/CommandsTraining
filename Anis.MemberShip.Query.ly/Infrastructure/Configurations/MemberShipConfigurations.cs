using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anis.MemberShip.Query.ly.Infrastructre.Configurations
{
    public class MemberShipConfigurations : IEntityTypeConfiguration<MemberShipEntity>
    {
        public void Configure(EntityTypeBuilder<MemberShipEntity> builder)
        {
            builder.Property(x => x.Sequence).IsConcurrencyToken();
        }
    }
}
