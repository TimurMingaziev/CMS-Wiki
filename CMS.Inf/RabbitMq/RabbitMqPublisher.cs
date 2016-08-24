using System;
using System.Text;
using RabbitMQ.Client;

namespace CMS.Inf.RabbitMq
{
    public class RabbitMqPublisher : IRabbitMq
    {
        private IModel _channel;

        public RabbitMqPublisher(IModel channel)
        {
            _channel = channel;
        }


        public IModel Connect(string host)
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
