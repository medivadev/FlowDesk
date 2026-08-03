using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Application.Features.Projects.CreateProject;

public record Command(
    string Name,
    string Description,
    Guid WorkspaceId);
