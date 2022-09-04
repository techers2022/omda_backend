namespace OMDA.Models.Request;

public class UpdateUserModel
{
    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Description { get; set; }
}
