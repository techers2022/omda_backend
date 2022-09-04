using Microsoft.AspNetCore.Mvc;
using OMDA.Models.Request;
using OMDA.Models.Response;
using OMDA.Services;

namespace OMDA.Endpoints;

public static class UpdateUserEndpoint
{
    public static IEndpointRouteBuilder MapUpdateUserEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut("/update-user/{id}", async ([FromRoute] string id, [FromBody] UpdateUserModel model, UsersService usersService) =>
        {
            var user = await usersService.GetUserByIdAsync(id);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Description = model.Description;

            await usersService.UpdateAsync(id, user);

            var response = new UserModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Description = user.Description
            };

            return Results.Ok(response);
        });

        return endpoints;
    }
}