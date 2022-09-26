using Microsoft.AspNetCore.Mvc;
using OMDA.Models.Entities;
using OMDA.Models.Request;
using OMDA.Models.Response;
using OMDA.Services;

namespace OMDA.Endpoints;

public static class AcceptWorkEndpoint
{
    public static IEndpointRouteBuilder MapAcceptWorkEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/accept-work", async ([FromBody] AcceptWorkModel model, WorksService worksService) =>
        {
            await worksService.AcceptWorkByUserAsync(model.WorkId, model.UserId);

            return Results.Ok();
        });

        return endpoints;
    }
}