using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TradingEngine.Core.Configuration;

namespace TradingEngine.Core
{
    class TradingEngineServer : BackgroundService, ITradingEngine
    {
        private readonly IOptions<TradingEngineServerConfiguration> _engineConfiguration;
        private readonly ILogger<TradingEngineServer> _logger;

        public TradingEngineServer(IOptions<TradingEngineServerConfiguration> engineConfiguration,
            ILogger<TradingEngineServer> logger)
        {
            _engineConfiguration = engineConfiguration ?? throw new ArgumentNullException(nameof(engineConfiguration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task RunAsync(CancellationToken token) => ExecuteAsync(token);

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Started {nameof(TradingEngineServer)}");
            while (!stoppingToken.IsCancellationRequested)
            {

            }
            _logger.LogInformation($"Stopped {nameof(TradingEngineServer)}");
            return Task.CompletedTask;
        }
    }
}
