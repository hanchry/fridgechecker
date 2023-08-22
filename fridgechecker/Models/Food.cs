namespace fridgechecker.Models;

public class Food
{
    public int Id { get; set; }
    public int StorageId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public int? Amount { get; set; }
    public string? AmountType { get; set; }
    public string? Type { get; set; }
}