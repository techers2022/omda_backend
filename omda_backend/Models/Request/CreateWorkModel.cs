namespace OMDA.Models.Request;

public class CreateWorkModel
{
    public string UserId { get; set; } = null!;

    public string Category { get; set; } = null!;

    public decimal Price { get; set; }

    public string Duration { get; set; } = null!;

    public string Date { get; set; } = null!;

    public string Description { get; set; } = null!;
}
