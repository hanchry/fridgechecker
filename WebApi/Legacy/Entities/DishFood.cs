using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fridgechecker.Legacy.Entities;

[Table("dish_food")]
public class DishFood
{
    [Key] [Column("id")] public int Id { get; set; }
    [Column("dish_id")] public int? DishId { get; set; }
    [Column("food_id")] public int? FoodId { get; set; }
    [Column("amount")] public int? Amount { get; set; }
    [Column("amount_type")] public string? AmountType { get; set; }
    
    [ForeignKey(nameof(DishId))]
    [InverseProperty(nameof(Dish.DishFoods))]
    public virtual Dish DishRecipe { get; set; }
    
    [ForeignKey(nameof(FoodId))]
    [InverseProperty(nameof(Food.DishFoods))]
    public virtual Food FoodIngredience { get; set; }
}