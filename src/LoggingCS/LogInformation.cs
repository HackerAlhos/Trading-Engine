using System;
using System.Collections.Generic;
using System.Text;

namespace TradingEngine.Logging
{
    public record LogInformation(LogLevel LogLevel, DateTime LogTime, int ThreadId, string ThreadName, string Message, string Module);
}

namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { };
}
