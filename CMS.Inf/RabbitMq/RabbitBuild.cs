using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CMS.Inf.RabbitMq
{
    public class RabbitBuild
    {
        IModel _channel;
        private object _serviceObject;
        private string _queueName;
        private EventingBasicConsumer _eventingBasicConsumer;
        private RabbitMqPublisher _rabbitMqSender;
        
        public RabbitBuild(IModel chanel, string queueName, RabbitMqPublisher sender)
        {
            _rabbitMqSender = sender;
            _queueName = queueName;
            _channel = chanel;
            _channel.QueueDeclare(_queueName, false, false, false, null);
            _channel.BasicQos(0, 100, false);
            _eventingBasicConsumer = new EventingBasicConsumer(_channel);
            _eventingBasicConsumer.Received += EventReceiver;
            _channel.BasicConsume(_queueName, true, _eventingBasicConsumer);
        }
        public void EventReceiver(object ch, BasicDeliverEventArgs ea)
        {
            
            var body = ea.Body;
            string message = "";
            try
            {
                message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
