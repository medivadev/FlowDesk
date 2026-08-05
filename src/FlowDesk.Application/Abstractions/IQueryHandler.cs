using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Application.Abstractions;

public interface IQueryHandler<in TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}
