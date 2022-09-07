namespace OMDA.Models.Response;

public class WorkDetailedModel
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string Category { get; set; } = null!;

    public decimal Price { get; set; }

    public byte Hours { get; set; }

    public DateTime Date { get; set; }

    public string Description { get; set; } = null!;
}
