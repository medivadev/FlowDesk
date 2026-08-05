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
    public Guid? OrganizationId { get; private set; }

    private User()
    {
        Email = string.Empty;
        PasswordHash = string.Empty;
        FullName = string.Empty;
    }

    public static User Create(string email,  string passwordHash,  string fullName, Guid? organizationId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(passwordHash);

        return new User
        {
            Id = Guid.CreateVersion7(),
            Email = email.ToLowerInvariant().Trim(),
            PasswordHash = passwordHash,
            FullName = fullName,
            OrganizationId = organizationId,
            CreatedAtUtc = DateTime.UtcNow
        };
    }
}
