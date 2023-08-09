namespace fridgechecker.Legacy.Models;

public class StorageDB
{
    public int Id { get; set; }
    public int? HouseHoldId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
}