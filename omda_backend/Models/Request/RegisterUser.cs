﻿namespace OMDA.Models.Request;

public class CreateUser
{
    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
