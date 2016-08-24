using System;
using System.Text;
using NLog;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using CMS.Data;
using Newtonsoft.Json;

namespace CMS.Inf.RabbitMq
{
    public class RabbitBuild
    {
        private ILogger _logger;
        private IModel _channel;
        private EventingBasicConsumer _eventingBasicConsumer;
        private string _queue;

        public RabbitBuild(ILogger logger,IModel channel, string queue)
        {
            _logger = logger;
            _queue = queue;
            _channel = channel;
            _channel.QueueDeclare(_queue, false, false, false, null);
            _channel.BasicQos(0, 100, false);
            _eventingBasicConsumer = new EventingBasicConsumer(_channel);
            _eventingBasicConsumer.Received += EventReceiver;
            _channel.BasicConsume(_queue, true, _eventingBasicConsumer);

        }
       
        public void EventReceiver(object ch, BasicDeliverEventArgs ea)
        {
            _logger.Info("rabbitmq catch event");
            
            var response = string.Empty;
            var body = ea.Body;
            var props = ea.BasicProperties;
            var replyProps = _channel.CreateBasicProperties();
            replyProps.CorrelationId = props.CorrelationId;
            string message = "";
            try
            {
                message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
                this.GetResult(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void GetResult(string message)
        {
            var data = JsonConvert.DeserializeObject<MessageRabbitClass>(message);
            try
            {
                Console.WriteLine(data.MethodName, data.Data);
                var _dto = WhatIsClass(data.MethodName, data.Data);
                Console.WriteLine(_dto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public object WhatIsClass(string methodName, object data)
        {
            switch (methodName)
            {
                case "CreatePage": return (PageDto)data;
                    break;
                case "CreateComment": return (CommentDto)data;
                default:
                    return null;
            }
        }

        private void CallMethod(string methodName, object param)
        {
            
        }
    }
}
