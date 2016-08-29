using System;
using System.Reflection;
using System.Text;
using NLog;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using CMS.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Util;
using  System.Timers;

namespace CMS.Inf.RabbitMq
{
    public class RabbitBuild
    {
        private ILogger _logger;
        private IModel _channel;
      //  private EventingBasicConsumer _eventingBasicConsumer;
        private string _queue;
        object _usercase;
        RabbitMqPublisher _rabbitMqPublisher;
        IBasicProperties _replyProps;
        
        public RabbitBuild(ILogger logger,IModel channel, string queue, object usercase)
        {
            
            _usercase = usercase;
            _logger = logger;
            _queue = queue;
            _channel = channel;
            _channel.QueueDeclare(_queue, false, false, false, null);
            _channel.BasicQos(0, 100, false);
            _rabbitMqPublisher = new RabbitMqPublisher(_channel);
            EventingBasicConsumer eventingBasicConsumer = new EventingBasicConsumer(_channel);
            eventingBasicConsumer.Received += EventReceiver;
            channel.BasicConsume(_queue, true, eventingBasicConsumer);

        }
       
        public void EventReceiver(object ch, BasicDeliverEventArgs ea)
        {
            _logger.Info("rabbitmq catch event");
            
            var response = string.Empty;
            var body = ea.Body;
            var props = ea.BasicProperties;
            _replyProps = _channel.CreateBasicProperties();
            _replyProps.CorrelationId = props.CorrelationId;
            string message = "";
            try
            {
                message = Encoding.UTF8.GetString(body);
                _logger.Info("JSON is comming: {0}", message);
                
               GetResult(message);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
        }

        public void GetResult(string message)
        {
            try
            {
                _logger.Info("Start parsing");
                var data = JsonConvert.DeserializeObject<MessageRabbitClass>(message);
                Console.WriteLine(data.MethodName, data.Data);
                object dto = WhatIsClass(data.MethodName, (JObject) data.Data);
                var method = _usercase.GetType().GetMethod(data.MethodName);
                var methodParameters = method.GetParameters();

                foreach (var VARIABLE in methodParameters)
                {
                    Console.WriteLine(VARIABLE);
                }
                method.Invoke(_usercase, new object[] {dto});

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }
        public object WhatIsClass(string methodName, JObject data)
        {
            switch (methodName)
            {
                case "CreatePage": return data.ToObject<PageDto>();
                case "CreateComment": return data.ToObject<CommentDto>();
                default:
                    return null;
            }
        }

        public void SendEvent()
        {
            _rabbitMqPublisher.Send("","rec_con", _replyProps, "created");
        }
        private void CallMethod(string methodName, object param)
        {
            
        }
    }
}
