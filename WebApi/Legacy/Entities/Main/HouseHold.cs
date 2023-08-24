using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fridgechecker.Legacy.Entities;

[Table("house_hold")]
public class HouseHold
{
    public HouseHold()
    {
       
    }
    [Key] [Column("id")] public int Id { get; set; }
    [Required] [StringLength(25)] [Column("name")] public string Name { get; set; }
    [StringLength(25)] [Column("city")] public string City { get; set; }
    [StringLength(25)] [Column("address")] public string Address { get; set; }
    
    [InverseProperty(nameof(UserHouseHold.HouseHoldOwnd))]
    public virtual IList<UserHouseHold> UserHouseHolds { get; set; }
    
    [InverseProperty(nameof(Storage.houseHold))]
    public virtual ICollection<Storage> Storages { get; set; }
}