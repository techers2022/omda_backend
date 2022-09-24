using Microsoft.AspNetCore.Mvc;
using OMDA.Models.Entities;
using OMDA.Models.Request;
using OMDA.Models.Response;
using OMDA.Services;

namespace OMDA.Endpoints;

public static class CreateWorkEndpoint
{
    public static IEndpointRouteBuilder MapCreateWorkEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/create-work", async ([FromBody] CreateWorkModel model, WorksService worksService) =>
        {
            var work = new Work
            {
                UserId = model.UserId,
                Title = model.Title,
                Category = model.Category,
                Price = model.Price,
                Location = model.Location,
                Duration = model.Duration,
                Date = model.Date,
                Description = model.Description,
            };

            await worksService.CreateAsync(work);

            return Results.Created($"/get-work-detailed/{work.Id}", work);
        });

        return endpoints;
    }
}