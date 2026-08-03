using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Application.Interfaces.Services;

public interface IJwtTokenService
{
    string GenerateToken(Guid userId, string email, string fullName);
}
