namespace fridgechecker.Models;

public class Storage
{
    public int Id { get; set; }
    public int HouseHoldId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
}