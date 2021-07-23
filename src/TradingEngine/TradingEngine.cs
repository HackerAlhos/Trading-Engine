using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TradingEngine.Core
{
    class TradingEngine : BackgroundService, ITradingEngine
    {
        private readonly IOptions<TradingEngineConfiguration> _engineConfiguration;
        private readonly ILogger<TradingEngine> _logger;

        public TradingEngine(IOptions<TradingEngineConfiguration> engineConfiguration,
            ILogger<TradingEngine> logger)
        {
            _engineConfiguration = engineConfiguration ?? throw new ArgumentNullException(nameof(engineConfiguration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Trading engine online.");
            while (!stoppingToken.IsCancellationRequested)
            { }
            return Task.CompletedTask;
        }
    }
}
