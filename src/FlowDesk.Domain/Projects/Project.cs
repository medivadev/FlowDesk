using FlowDesk.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Domain.Projects;

public sealed class Project : AuditableEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Guid OrganizationId { get; private set; }

    private Project()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public Project(Guid id, string name, string description, Guid organizationId)
    {
        Id = id;
        Name = name;
        Description = description;
        OrganizationId = organizationId;
        CreatedAtUtc = DateTime.UtcNow;
    }
}
