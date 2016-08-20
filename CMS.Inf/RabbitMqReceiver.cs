using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace CMS.Inf
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
