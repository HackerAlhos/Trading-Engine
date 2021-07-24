using System;
using System.Collections.Generic;
using System.Text;

namespace TradingEngine.Core.Configuration
{
    public class TradingEngineServerConfiguration
    {
        public TradingEngineServerSettings TradingEngineServerSettings { get; set; }
    }

    public class TradingEngineServerSettings
    {
        public int Port { get; set; }
    }
}
