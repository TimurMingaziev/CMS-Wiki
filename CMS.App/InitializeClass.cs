using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Inf.RabbitMq;
using NLog;
using RabbitMQ.Client;

namespace CMS.App
{
    public class InitializeClass
    {

        ILogger _logger;
        IModel _connector;
        public InitializeClass(ILogger logger)
        {
            _logger = logger;
            _logger.Log(LogLevel.Info,"Start init");
            _connector = new RabbitConnector(logger).Connect("localhost");
            var rpc = new RabbitBuild(_connector,"rec_con");
        }
    }
}
