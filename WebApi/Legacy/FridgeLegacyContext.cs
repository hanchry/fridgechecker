using fridgechecker.Legacy.Entities;

using Microsoft.EntityFrameworkCore;

namespace fridgechecker.Legacy;

public class FridgeLegacyContext: DbContext
{
    public virtual DbSet<HouseHold> HouseHolds { get; set; }
    public virtual DbSet<Storage> Storages { get; set; }
    public virtual DbSet<Dish> Dishes { get; set; }
    public virtual DbSet<Food> Foods { get; set; }
    public virtual DbSet<User> Users { get; set; }
    
    public virtual DbSet<DishFood> DishFoods { get; set; }
    public virtual DbSet<UserDish> UserDishes { get; set; }
    public virtual DbSet<UserHouseHold> UserHouseHolds { get; set; }

    public FridgeLegacyContext(DbContextOptions<FridgeLegacyContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}