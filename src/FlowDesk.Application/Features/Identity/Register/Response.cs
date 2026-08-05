using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Application.Features.Identity.Register;

public sealed record Response(
    Guid Id,
    string FullName,
    string Email,
    string Token);
