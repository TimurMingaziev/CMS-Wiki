using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CMS.Inf.RabbitMq
{
    class RabbitMqReceiver
    {
        private IModel _channel;
        private EventingBasicConsumer _eventingBasicConsumer;

        public RabbitMqReceiver(IModel channel)
        {
            _channel = channel;
            _eventingBasicConsumer = new EventingBasicConsumer(_channel);
        }
       

    }
}
