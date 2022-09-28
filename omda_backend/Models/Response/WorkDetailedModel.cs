namespace OMDA.Models.Response;

public class WorkDetailedModel
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string UserFullName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserPhone { get; set; } = null!;

    public string? AcceptedByUserId { get; set; }

    public string? AcceptedByUserFullName { get; set; }

    public string? AcceptedByUserEmail { get; set; }

    public string? AcceptedByUserPhone { get; set; }

    public string Title { get; set; } = null!;

    public string Category { get; set; } = null!;

    public decimal Price { get; set; }

    public string Duration { get; set; } = null!;

    public string Date { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Description { get; set; } = null!;
}
