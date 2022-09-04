using Microsoft.AspNetCore.Mvc;
using OMDA.Models.Request;
using OMDA.Models.Response;
using OMDA.Services;

namespace OMDA.Endpoints;

public static class LoginEndpoint
{
    public static IEndpointRouteBuilder MapLoginEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/login", async ([FromBody] LoginUserModel model, UsersService usersService) =>
        {
            var user = await usersService.GetByEmailAsync(model.Email!);

            if (user is null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return Results.NotFound();
            }

            var response = new UserModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Description = user.Description,
            };

            return Results.Ok(response);
        });

        return endpoints;
    }
}