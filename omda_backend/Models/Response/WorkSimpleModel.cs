namespace OMDA.Models.Response;

public class WorkSimpleModel
{
    public string Id { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Category { get; set; } = null!;

    public decimal Price { get; set; }

    public string Duration { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string ShortDescription { get; set; } = null!;
}