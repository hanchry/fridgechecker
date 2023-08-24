using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fridgechecker.Legacy.Entities;

[Table("food")]
public class Food
{
    [Key] [Column("id")] public int Id { get; set; }
    [Column("storage_id")] public int? StorageId { get; set; }
    [Column("name")] public string Name { get; set; }
    [Column("description")] public string? Description { get; set; }
    [Column("image")] public string? Image { get; set; }
    [Column("expiration_date")] public DateTime? ExpirationDate { get; set; }
    [Column("amount")] public int? Amount { get; set; }
    [Column("amount_type")] public string? AmountType { get; set; }
    [Column("type")] public string? Type { get; set; }
    
    [InverseProperty(nameof(DishFood.FoodIngredience))]
    public virtual IList<DishFood> DishFoods { get; set; }
    
    [ForeignKey(nameof(StorageId))]
    [InverseProperty(nameof(Storage.Foods))]
    public virtual Storage storage { get; set; }
    
}