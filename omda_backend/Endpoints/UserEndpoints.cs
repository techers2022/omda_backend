using OMDA.Models.Entities;
using OMDA.Services;

namespace OMDA.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/users", async (UsersService usersService) =>
        {
            var users = await usersService.GetAsync();
            return Results.Ok(users);
        });

        endpoints.MapGet("/users/{id:length(24)}", async (string id, UsersService usersService) =>
        {
            var user = await usersService.GetAsync(id);

            return user is not null ? Results.Ok(user) : Results.NotFound();
        });

        endpoints.MapPost("/users", async (User user, UsersService usersService) =>
        {
            await usersService.CreateAsync(user);
            return Results.Created($"/users/{user.Id}", user);
        });

        return endpoints;
    }
}