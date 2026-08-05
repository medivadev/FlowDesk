using FlowDesk.Application.Features.Projects.CreateProject;
using FlowDesk.Application.Abstractions;


namespace FlowDesk.Api.Endpoints.Projects;

public static class CreateProjectEndpoint
{
    public static void MapCreateProject(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/projects", async (
            Command command,
            ICommandHandler<Command, Response> handler,
            CancellationToken cancellationToken) =>
        {
            var result = await handler.HandleAsync(command, cancellationToken);
            return Results.Created($"/api/projects/{result.Id}", result);
        }).WithTags("Projects");
    }
}
