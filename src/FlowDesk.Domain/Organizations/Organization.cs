using FlowDesk.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Domain.Organizations;

public sealed class Organization : AuditableEntity
{
    public string Name { get; private set; }

    private Organization() { Name = string.Empty; }

    public Organization(Guid id,  string name)
    {
        Id = id;
        Name = name;
        CreatedAtUtc = DateTime.UtcNow;
    }
}
