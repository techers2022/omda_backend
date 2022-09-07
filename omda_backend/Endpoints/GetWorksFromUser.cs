using Microsoft.AspNetCore.Mvc;
using OMDA.Models.Request;
using OMDA.Models.Response;
using OMDA.Services;

namespace OMDA.Endpoints;

public static class GetWorksFromUserEndpoint
{
    public static IEndpointRouteBuilder MapGetWorksFromUserEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/get-works-from-user/{userId}", async ([FromRoute] string userId, WorksService worksService) =>
        {
            var works = await worksService.GetAllFromUserAsync(userId);

            var response = works.Select(x => new WorkSimpleModel
            {
                Id = x.Id,
                UserId = x.UserId,
                Category = x.Category,
                Price = x.Price,
                Hours = x.Hours,
                Description = x.Description,
            }).ToList();

            return Results.Ok(response);
        });

        return endpoints;
    }
}