using Microsoft.AspNetCore.Mvc;
using OMDA.Models.Response;
using OMDA.Services;

namespace OMDA.Endpoints;

public static class GetWorksAcceptedByUserEndpoint
{
    public static IEndpointRouteBuilder MapGetWorksAcceptedByUserEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/get-works-accepted-by-user/{userId}", async ([FromRoute] string userId, WorksService worksService) =>
        {
            var works = await worksService.GetAllAcceptedByUserAsync(userId);

            var response = works.Select(x => new WorkSimpleModel
            {
                Id = x.Id,
                Title = x.Title,
                Category = x.Category,
                Price = x.Price,
                Duration = x.Duration,
                Location = x.Location,
                ShortDescription = x.Description.Length > 50 ? $"{x.Description[..47]}..." : x.Description,
            }).ToList();

            return Results.Ok(response);
        });

        return endpoints;
    }
}