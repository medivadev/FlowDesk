using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Application.Abstractions;

public interface ICommandHandler<in TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
