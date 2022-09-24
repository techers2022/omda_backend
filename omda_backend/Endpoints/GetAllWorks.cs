using Microsoft.AspNetCore.Mvc;
using OMDA.Models.Response;
using OMDA.Services;

namespace OMDA.Endpoints;

public static class GetAllWorks
{
    public static IEndpointRouteBuilder MapGetAllWorksEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/get-all-works", async ([FromServices] WorksService worksService) =>
        {
            var works = await worksService.GetAllAsync();

            var response = works.Select(x => new WorkSimpleModel
            {
                Id = x.Id,
                UserId = x.UserId,
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