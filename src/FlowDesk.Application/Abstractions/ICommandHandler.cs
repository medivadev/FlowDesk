using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Application.Abstractions;

internal interface ICommandHandler<in TCommand, TResult>
{
    Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
