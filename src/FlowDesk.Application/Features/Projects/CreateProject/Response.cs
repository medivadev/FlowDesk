using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Application.Features.Projects.CreateProject;

public record Response(
    Guid Id,
    string Name,
    DateTime CreatedAt);
