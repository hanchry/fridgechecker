using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fridgechecker.Legacy.Entities;

[Table("storage")]
public class Storage
{
    [Key] [Column("id")] public int Id { get; set; }
    [Column("house_hold_id")] public int? HouseHoldId { get; set; }
    [Column("name")] [StringLength(25)] public string Name { get; set; }
    [Column("description")] public string? Description { get; set; }
    [Column("image")] public string? Image { get; set; }
    

    [InverseProperty(nameof(Food.storage))]
    public virtual ICollection<Food> Foods { get; set; }
    
    [ForeignKey(nameof(HouseHoldId))]
    [InverseProperty(nameof(HouseHold.Storages))]
    public virtual HouseHold houseHold { get; set; }

}