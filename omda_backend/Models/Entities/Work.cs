using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OMDA.Models.Entities;

public class Work
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string? AcceptedByUserId { get; set; }

    public string Title { get; set; } = null!;

    public string Category { get; set; } = null!;

    public decimal Price { get; set; }

    public string Duration { get; set; } = null!;

    public string Date { get; set; } = null!;

    public string Location { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Closed { get; set; } = false;
}