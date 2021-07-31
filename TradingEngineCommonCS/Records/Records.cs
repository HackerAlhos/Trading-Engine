using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

// Dumb bug.
// https://stackoverflow.com/questions/62648189/testing-c-sharp-9-0-in-vs2019-cs0518-isexternalinit-is-not-defined-or-imported

namespace System.Runtime.CompilerServices
{
    internal sealed class IsExternalInit { }
}

namespace TradingEngineCommonCS.Records
{
    public record OrderInformation(string Username, ulong OrderId, int SecurityId);
    public record OrderNew(DateTime SendTime, OrderInformation OrderInformation, bool IsBuy, long Price, int Quantity);
    public record OrderCancel(DateTime SendTime, OrderInformation OrderInformation);
    public record OrderFill(DateTime EventTime, int FillId, string ExecutionId, long Price, int Quantity); 
    
    public record OrderActionUpdate(UpdateType UpdateType, OrderNew OrderNew, OrderCancel OrderCancel);

    public record OrderNewStatus();
    public record OrderCancelStatus();
    public record OrderFillStatus();
    public record OrderActionResponse(ResponseType ResponseType, int ResponseId, OrderNewStatus, OrderCancelStatus, OrderFillStatus);

    public record ResponseTimestamp(DateTime EventTime, DateTime SendTime);
}
