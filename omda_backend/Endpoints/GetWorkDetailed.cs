using Microsoft.AspNetCore.Mvc;
using OMDA.Models.Request;
using OMDA.Models.Response;
using OMDA.Services;

namespace OMDA.Endpoints;

public static class GetWorksDetailedEndpoint
{
    public static IEndpointRouteBuilder MapGetWorkDetailedEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/get-work-detailed/{workId}", async ([FromRoute] string workId, WorksService worksService) =>
        {
            var work = await worksService.GetByIdAsync(workId);

            if (work is null) return Results.NotFound();

            var response = new WorkDetailedModel 
            {
                Id = work.Id,
                UserId = work.UserId,
                Category = work.Category,
                Price = work.Price,
                Hours = work.Hours,
                Date = work.Date,
                Description = work.Description,
            };

            return Results.Ok(response);
        });

        return endpoints;
    }
}