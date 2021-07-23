using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace TradingEngine.Core
{
    public sealed class TradingEngineHostBuilder
    {
        public static IHost BuildTradingEngine()
            => Host.CreateDefaultBuilder().ConfigureServices((hostContext, services)
                =>
                {
                    // Start with configurations.
                    services.AddOptions();
                    services.Configure<TradingEngineConfiguration>(hostContext.Configuration.GetSection(nameof(TradingEngineConfiguration)));

                    // Add singleton objects.
                    services.AddSingleton<ITradingEngine, TradingEngine>();

                    // Add hosted service.
                    services.AddHostedService<TradingEngine>();
                }).Build();
    }
}
