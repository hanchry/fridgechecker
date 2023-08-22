namespace fridgechecker.Models;

public class HouseHold
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
}