using Microsoft.AspNetCore.Mvc;
using OMDA.Models.Entities;
using OMDA.Models.Request;
using OMDA.Services;

namespace OMDA.Endpoints;

public static class RegisterEndpoint
{
    public static IEndpointRouteBuilder MapRegisterEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/register", async ([FromBody] RegisterUserModel model, [FromServices] UsersService usersService) =>
        {
            var user = new User
            {
                Email = model.Email,
                Phone = model.Phone,
                Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            await usersService.CreateAsync(user);

            return Results.Ok();
        });

        return endpoints;
    }
}