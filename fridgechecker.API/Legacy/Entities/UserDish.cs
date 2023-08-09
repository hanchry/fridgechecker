using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fridgechecker.Legacy.Entities;

[Table("user_dish")]
public class UserDish
{
    [Key] [Column("id")] public int Id { get; set; }
    [Column("user_id")] public int? UserId { get; set; }
    [Column("dish_id")] public int? DishId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    [InverseProperty(nameof(User.UserDishes))]
    public virtual User UserOwner { get; set; }
    
    [ForeignKey(nameof(DishId))]
    [InverseProperty(nameof(Dish.UserDishes))]
    public virtual Dish DishOwner { get; set; }
}