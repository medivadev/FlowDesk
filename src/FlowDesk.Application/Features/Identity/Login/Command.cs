using FlowDesk.Application.Abstractions;
using FlowDesk.Application.Features.Identity.Register;

namespace FlowDesk.Application.Features.Identity.Login;

public sealed record Command(
    string Email,
    string Password) : ICommand<Response>;
