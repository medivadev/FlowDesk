using System;
using System.Collections.Generic;
using System.Text;

namespace FlowDesk.Application.Abstractions;

public interface ICommand<out TResult> { }
