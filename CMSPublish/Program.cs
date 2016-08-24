using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using CMS.Data;
using Newtonsoft.Json;

namespace CMSPublish
{
    class RPCClient
    {
        private IConnection connection;
        private IModel channel;
        private string replyQueueName;
        private QueueingBasicConsumer consumer;

        public RPCClient()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            replyQueueName = channel.QueueDeclare().QueueName;
            consumer = new QueueingBasicConsumer(channel);
            channel.BasicConsume(queue: replyQueueName,
                                 noAck: true,
                                 consumer: consumer);
        }

        public string Call(object message,  string routingKey)
        {
            var corrId = Guid.NewGuid().ToString();
            var props = channel.CreateBasicProperties();
            props.ReplyTo = replyQueueName;
            props.CorrelationId = corrId;
            var stringMessage = JsonConvert.SerializeObject(message);
            var messageBytes = Encoding.UTF8.GetBytes(stringMessage);
            channel.BasicPublish(exchange: "",
                                 routingKey: routingKey,
                                 basicProperties: props,
                                 body: messageBytes);

            while (true)
            {
                var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();
                if (ea.BasicProperties.CorrelationId == corrId)
                {
                    return Encoding.UTF8.GetString(ea.Body);
                }
            }
        }

        public void Close()
        {
            connection.Close();
        }
    }

    class RPC
    {

        public static void Main()
        {
            var rpcClient = new RPCClient();

            PageDto page = new PageDto { NamePage = "1", ContentPage = "22", ChangerPage = "1", OwnerPage = "1", DateChangePage = DateTime.Now, DateCreatePage = DateTime.Now, SectionId = 1 };
           
            Console.WriteLine(" [x] Requesting fib(30)");
            MessageRabbitClass msg = new MessageRabbitClass
            {
                MethodName = "CreatePage",
                Data = page
            };
            var response = rpcClient.Call(msg, "func1");
            Console.WriteLine(" [.] Got '{0}'", response);
            Console.ReadLine();
            rpcClient.Close();
        }
    }
}
