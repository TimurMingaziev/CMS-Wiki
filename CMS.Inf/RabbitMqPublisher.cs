using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace CMS.Inf
{
    public class RabbitMqPublisher : IRabbitMq
    {
        private IModel _channel;

        public RabbitMqPublisher(IModel channel)
        {
            _channel = channel;
        }


        public IModel Connect(string host, IModel channel)
        {
            throw new NotImplementedException();
        }

        public void publish()
        {
            throw new NotImplementedException();
        }

        public void Send(string exchangeName, string routingKey, string message)
        {
            _channel.ExchangeDeclare(exchangeName, "topic");
            _channel.BasicPublish(exchangeName,
                                routingKey,
                                null,
                                Encoding.UTF8.GetBytes(message));
        }
    }
}
