using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fridgechecker.Legacy.Entities;

[Table("user_house_hold")]
public class UserHouseHold
{
    [Key] [Column("id")] public int Id { get; set; }
    [Column("user_id")] public int? UserId { get; set; }
    [Column("house_hold_id")] public int? HouseHoldId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    [InverseProperty(nameof(User.UserHouseHolds))]
    public virtual User UserOwner { get; set; }
    
    [ForeignKey(nameof(HouseHoldId))]
    [InverseProperty(nameof(HouseHold.UserHouseHolds))]
    public virtual HouseHold HouseHoldOwnd { get; set; }
}