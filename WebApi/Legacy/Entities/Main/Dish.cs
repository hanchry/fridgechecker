using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fridgechecker.Legacy.Entities;

[Table("dish")]
public class Dish
{
    public Dish()
    {
        
    }
    [Key] [Column("id")] public int Id { get; set; }
    [Column("name")] public string Name { get; set; }
    [Column("description")] public string? Description { get; set; }
    [Column("image")] public string? Image { get; set; }
    
    [InverseProperty(nameof(UserDish.DishOwner))]
    public virtual IList<UserDish> UserDishes { get; set; }
    
    [InverseProperty(nameof(DishFood.DishRecipe))]
    public virtual IList<DishFood> DishFoods { get; set; }
    
}