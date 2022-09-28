using Microsoft.AspNetCore.Mvc;
using OMDA.Models.Response;
using OMDA.Services;

namespace OMDA.Endpoints;

public static class GetWorksDetailedEndpoint
{
    public static IEndpointRouteBuilder MapGetWorkDetailedEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/get-work-detailed/{workId}", async ([FromRoute] string workId, [FromServices] WorksService worksService, [FromServices] UsersService usersService) =>
        {
            var work = await worksService.GetByIdAsync(workId);
            var user = await usersService.GetUserByIdAsync(work!.UserId);
            var acceptedByUser = work!.AcceptedByUserId == null ? null : await usersService.GetUserByIdAsync(work!.AcceptedByUserId);

            if (work is null) return Results.NotFound();

            var response = new WorkDetailedModel 
            {
                Id = work.Id,
                UserId = work.UserId,
                UserFullName = $"{user.LastName} {user.FirstName}",
                UserEmail = user.Email,
                UserPhone = user.Phone,
                AcceptedByUserId = work.AcceptedByUserId,
                AcceptedByUserFullName = acceptedByUser == null ? null : $"{acceptedByUser.LastName} {acceptedByUser.FirstName}",
                AcceptedByUserEmail = acceptedByUser?.Email,
                AcceptedByUserPhone = acceptedByUser?.Phone,
                Title = work.Title,
                Category = work.Category,
                Price = work.Price,
                Duration = work.Duration,
                Date = work.Date,
                Location = work.Location,
                Description = work.Description,
            };

            return Results.Ok(response);
        });

        return endpoints;
    }
}