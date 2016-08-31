using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Inf;
using CMS.Inf.RabbitMq;
using CMS.Model.Domain;
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
        }
        public void StartInit()
        {
            _logger.Log(LogLevel.Info, "Start init");
            _connector = new RabbitConnector(_logger).Connect("localhost");
            var statistic = new StatisticData();
            var usecase = new UseCase(_logger);
            
            var rpc = new RabbitBuild(_logger, _connector, "rec_con", usecase, statistic);
        }
    }
}
