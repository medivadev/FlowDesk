
using FlowDesk.Application.Abstractions;

namespace FlowDesk.Application.Features.Identity.Register;

public sealed record Command(
    string Email,
    string Password,
    string FullName) : ICommand<Response>;
