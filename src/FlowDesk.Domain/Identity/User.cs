using FlowDesk.Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Domain.Identity;

public sealed class User : AuditableEntity
{
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string FullName { get; private set; }

    private User()
    {
        Email = string.Empty;
        PasswordHash = string.Empty;
        FullName = string.Empty;
    }

    public static User Create(string email,  string passwordHash,  string fullName)
    {
        return new User
        {
            Id = Guid.CreateVersion7(),
            Email = email.ToLowerInvariant().Trim(),
            PasswordHash = passwordHash,
            FullName = fullName,
            CreatedAtUtc = DateTime.UtcNow
        };
    }
}
