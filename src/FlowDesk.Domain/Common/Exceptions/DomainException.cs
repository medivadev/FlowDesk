using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Domain.Common.Exceptions;

public sealed class DomainException(string message)
    : Exception(message);