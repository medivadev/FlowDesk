using FlowDesk.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Application.Features.Projects.CreateProject;

internal sealed class Handler : ICommandHandler<Command, Response>
{
    public async Task<Response> HandleAsync(Command command, CancellationToken cancellationToken = default)
    {
        var projectId = Guid.CreateVersion7();

        return new Response(projectId, command.Name, DateTime.UtcNow);
    }
}
