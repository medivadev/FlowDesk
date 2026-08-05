using FlowDesk.Api.Endpoints.Projects;
using FlowDesk.Application.Abstractions;

namespace FlowDesk.Api.Extensions;

public static class EndpointExtensions
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        #region Projects

        app.MapCreateProject();

        #endregion
    }
}
