using System;
using RabbitMQ.Client;

namespace CMS.Inf.RabbitMq
{
    public class RabbitConnector : IRabbitMq
    {

        private string _host { get; set; }
        private IModel _channel { get; set;}

        public RabbitConnector() { }

        public IModel Connect(string host)
        {
            _host = host;
            var factory = new ConnectionFactory
            {
                HostName = _host
            };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            return _channel;
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
