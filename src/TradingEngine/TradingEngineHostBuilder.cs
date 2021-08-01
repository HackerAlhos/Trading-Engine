﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using TradingEngine.Core.Configuration;
using TradingEngine.Logging;

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
                    services.Configure<TradingEngineServerConfiguration>(hostContext.Configuration.GetSection(nameof(TradingEngineServerConfiguration)));
                    services.Configure<LoggerConfiguration>(hostContext.Configuration.GetSection(nameof(LoggerConfiguration)));

                    // Add singleton objects.
                    services.AddSingleton<ITextLogger, TextLogger>();
                    services.AddSingleton<ITradingEngine, TradingEngineServer>();

                    // Add hosted service.
                    services.AddHostedService<TradingEngineServer>();
                }).Build();
    }
}
