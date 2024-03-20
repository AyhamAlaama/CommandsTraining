
using Microsoft.EntityFrameworkCore;
namespace Anis.MemberShip.Query.ly.Infrastructre.Persistence;
    public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }
    public DbSet<MemberShipEntity> MemberShips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
    }
}

