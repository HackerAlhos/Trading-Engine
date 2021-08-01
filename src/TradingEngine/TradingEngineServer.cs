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
using TradingEngine.Logging;

namespace TradingEngine.Core
{
    class TradingEngineServer : BackgroundService, ITradingEngine
    {
        private readonly IOptions<TradingEngineServerConfiguration> _engineConfiguration;
        private readonly ITextLogger _textLogger;

        public TradingEngineServer(IOptions<TradingEngineServerConfiguration> engineConfiguration,
            ITextLogger textLogger)
        {
            _engineConfiguration = engineConfiguration ?? throw new ArgumentNullException(nameof(engineConfiguration));
            _textLogger = textLogger ?? throw new ArgumentNullException(nameof(textLogger));
        }

        public Task RunAsync(CancellationToken token) => ExecuteAsync(token);

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _textLogger.Information(nameof(TradingEngineServer), $"Starting Trading Engine");
            while (!stoppingToken.IsCancellationRequested)
            {

            }
            _textLogger.Information(nameof(TradingEngineServer), $"Stopping Trading Engine");
            return Task.CompletedTask;
        }
    }
}
