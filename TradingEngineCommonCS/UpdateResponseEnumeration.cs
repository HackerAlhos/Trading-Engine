using System;
using System.Collections.Generic;
using System.Text;

namespace TradingEngineCommonCS
{
    public enum UpdateType
    {
        OrderNew,
        OrderCancel,
    }

    public enum ResponseType
    {
        OrderNewStatus,
        OrderCancelStatus,
        OrderFillStatus,
    }
}
