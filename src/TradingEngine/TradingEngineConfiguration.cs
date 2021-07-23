using System;
using System.Collections.Generic;
using System.Text;

namespace TradingEngine.Core
{
    public class TradingEngineConfiguration
    {
        public OrderEntryServer OrderEntryServer { get; set; }
    }

    public class OrderEntryServer
    {
        public int Port { get; set; }
    }
}
