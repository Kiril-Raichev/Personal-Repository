using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Net_Core
{
    public interface IMessageWriter
    {
        void Write(string message);
    }

    public class LoggingMessageWriter : IMessageWriter
    {

        private readonly ILogger<LoggingMessageWriter> _logger;

        public LoggingMessageWriter(ILogger<LoggingMessageWriter> logger) =>
            _logger = logger;

        public void Write(string message) =>
            _logger.LogInformation(message);
    }
}
