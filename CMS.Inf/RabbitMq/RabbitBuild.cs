﻿using System;
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
        Timer _aTimer;
        StatisticData _statisticData;

        public RabbitBuild(ILogger logger,IModel channel, string queue, object usercase, StatisticData statisticData)
        {
            _statisticData = statisticData;
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
            StartTimer();

        }
       
        public void EventReceiver(object ch, BasicDeliverEventArgs ea)
        {
            _statisticData.CountOfRequests++;
            _logger.Info("rabbitmq catch event");
            
            var response = string.Empty;
            var body = ea.Body;
            var props = ea.BasicProperties;
            _replyProps = _channel.CreateBasicProperties();
            _replyProps.CorrelationId = props.CorrelationId;
            try
            {
                var message = Encoding.UTF8.GetString(body);
                _logger.Info("JSON is comming: {0}", message);
                
               GetResult(message);
                _rabbitMqPublisher.Send("", props.ReplyTo, _replyProps, "created");
                
                _statisticData.CountOfSuccess++;
            }
            catch (Exception e)
            {
                _rabbitMqPublisher.Send("", props.ReplyTo, _replyProps, "trouble");
                _logger.Error(e.Message);
                _statisticData.CountOfErrors++;
            }
        }

        public void GetResult(string message)
        {
            try
            {
                _logger.Info("Start parsing");
                var data = JsonConvert.DeserializeObject<MessageRabbitClass>(message);
                object dto = WhatIsClass(data.MethodName, (JObject) data.Data);
                CallMethod(data.MethodName, dto);
                
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }
        public object WhatIsClass(string methodName, JObject data)
        {
            switch (methodName)
            {
                case "CreatePage": return data.ToObject<PageDto>();
                case "CreateComment": return data.ToObject<CommentDto>();
                case "CreateMark":
                    return data.ToObject<MarkDto>();
                case "CreateSection":
                    return data.ToObject<SectionDto>();
                case "UpdatePage":
                    return data.ToObject<PageDto>();
                default:
                    return null;
            }
        }
        

        public void CallMethod(string methodName, object dto)
        {
            _logger.Info("Calling method");
            var method = _usercase.GetType().GetMethod(methodName);
            var methodParameters = method.GetParameters();

            foreach (var VARIABLE in methodParameters)
            {
                Console.WriteLine(VARIABLE);
            }
            method.Invoke(_usercase, new object[] { dto });
        }

        public void StartTimer()
        {
            _aTimer = new System.Timers.Timer(2000);
            _aTimer.Elapsed += OnTimedEvent;
            _aTimer.AutoReset = true;
            _aTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("Count of request: {0}, Count of success requset: {1}, Count of error request{2}", _statisticData.CountOfRequests, _statisticData.CountOfSuccess, _statisticData.CountOfErrors);
        }
    }
}
