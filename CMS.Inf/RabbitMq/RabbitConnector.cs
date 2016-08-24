using System;
using NLog;
using RabbitMQ.Client;

namespace CMS.Inf.RabbitMq
{
    public class RabbitConnector : IRabbitMq
    {

        private string _host { get; set; }
        private IModel _channel { get; set;}
        private ILogger _logger { get; set; }
        public RabbitConnector(ILogger logger)
        {
            _logger = logger;

        }

        public IModel Connect(string host)
        {
            _logger.Info("Connecting to rabbit server");
            _host = host;
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _host
                };
                var connection = factory.CreateConnection();
                _channel = connection.CreateModel();
            }
            catch (Exception)
            {
                _logger.Error("Bad connection (rabbit)");
                return null;
            }

            _logger.Info("Connected to rabbit");

            return _channel;
        }

        public void Disconnect()
        {
            _channel.Close();
            _logger.Info("Disconnected (rabbit)");
        }

        public void publish()
        {
            throw new NotImplementedException();
        }

        public void Send(string exchangeName, string routingKey, string message)
        {
            throw new NotImplementedException();
        }
    }
}
