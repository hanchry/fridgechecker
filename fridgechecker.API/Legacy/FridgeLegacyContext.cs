using fridgechecker.Legacy.Entities;

using Microsoft.EntityFrameworkCore;

namespace fridgechecker.Legacy;

public class FridgeLegacyContext: DbContext
{
    public virtual DbSet<HouseHold> HouseHolds { get; set; }
    
    public FridgeLegacyContext(DbContextOptions<FridgeLegacyContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}