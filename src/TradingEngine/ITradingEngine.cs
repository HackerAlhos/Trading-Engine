using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TradingEngine.Core
{
    interface ITradingEngine
    {
        Task RunAsync(CancellationToken token);
    }
}
