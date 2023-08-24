using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fridgechecker.Legacy.Entities;

[Table("user")]
public class User
{
    public User()
    {
        
    }
    [Key] [Column("id")] public virtual int Id { get; set; }
    [Required] [StringLength(25)] [Column("name")] public virtual string Name { get; set; }
    [Required] [Column("password")] public virtual string Password { get; set; }

    [InverseProperty(nameof(UserHouseHold.UserOwner))]
    public virtual IList<UserHouseHold> UserHouseHolds { get; set; }
    
    [InverseProperty(nameof(UserDish.UserOwner))]
    public virtual IList<UserDish> UserDishes { get; set; }
}