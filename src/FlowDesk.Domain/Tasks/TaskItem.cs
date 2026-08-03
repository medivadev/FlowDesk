using FlowDesk.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Domain.Tasks;

public sealed class TaskItem :AuditableEntity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Guid ProjectId { get; private set; }

    public int StatusId { get; private set; }
    public int PriorityId { get; private set; }

    private TaskItem() 
    {
        Title = string.Empty;
        Description = string.Empty;
    }

    public TaskItem(Guid id, string title, string description, Guid projectId)
    {
        Id = id;
        Title = title;
        Description = description;
        ProjectId = projectId;
        CreatedAtUtc = DateTime.UtcNow;

        StatusId = 1;
    }
}
