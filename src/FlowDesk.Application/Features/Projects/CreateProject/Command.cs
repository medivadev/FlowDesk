using FlowDesk.Application.Abstractions;

namespace FlowDesk.Application.Features.Projects.CreateProject;

public sealed record Command(
    string Name,
    string Description,
    Guid WorkspaceId): ICommand<Response>;
