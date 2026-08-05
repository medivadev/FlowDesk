using FlowDesk.Application.Abstractions;
using FlowDesk.Application.Interfaces.Repositories;
using FlowDesk.Application.Interfaces.Services;
using FlowDesk.Domain.Identity;

namespace FlowDesk.Application.Features.Identity.Register;

internal sealed class Handler(
    IUserRepository repository,
    IPasswordHasher passwordHasher,
    IJwtTokenService tokenService) : ICommandHandler<Command, Response>
{
    public async Task<Response> HandleAsync(Command command, CancellationToken cancellationToken = default)
    {
        if (await repository.ExistsByEmailAsync(command.Email, cancellationToken))
        {
            throw new InvalidOperationException("A user with this email already exists.");
        }

        var passwordHash = passwordHasher.Hash(command.Password);
        var user = User.Create(command.Email, passwordHash, command.FullName, null);

        await repository.AddAsync(user, cancellationToken);

        var token = tokenService.GenerateToken(user.Id, user.Email, user.FullName);
        return new Response(user.Id, user.FullName, user.Email, token);
    }
}
