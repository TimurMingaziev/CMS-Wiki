using System;
using System.Text;
using System.Threading;
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
            var factory = new ConnectionFactory() {HostName = "localhost"};
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            replyQueueName = channel.QueueDeclare().QueueName;
            consumer = new QueueingBasicConsumer(channel);
            channel.BasicConsume(queue: replyQueueName,
                noAck: true,
                consumer: consumer);
        }

        public string Call(object message, string routingKey)
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
                var ea = (BasicDeliverEventArgs) consumer.Queue.Dequeue();
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
            Console.WriteLine("Started");
            var rpcClient = new RPCClient();

            #region page

            //// PAGE ////////
            PageDto page = new PageDto
            {
                NamePage = "1",
                ContentPage = "22",
                ChangerPage = "1",
                OwnerPage = "1",
                DateChangePage = DateTime.Now,
                DateCreatePage = DateTime.Now,
                SectionId = 1
            };
            MessageRabbitClass msg = new MessageRabbitClass
            {
                MethodName = "CreatePage",
                Data = "12"
            };
            var response = rpcClient.Call(msg, "rec_con");
            Console.WriteLine(" [.] Got '{0}'", response);

            #endregion

            #region Mark

            ///// Mark //////////
            Thread.Sleep(5000);
            MarkDto mark = new MarkDto {DateMark = DateTime.Now, MarkThis = 1, OwnerMark = "me", PageId = 10};
            MessageRabbitClass msg2 = new MessageRabbitClass
            {
                MethodName = "CreateMark",
                Data = mark
            };
            var response2 = rpcClient.Call(msg2, "rec_con");
            Console.WriteLine(" [.] Got '{0}'", response2);

            #endregion

            #region Comment

            ////// Comment //////
            Thread.Sleep(5000);
            CommentDto comment = new CommentDto {ContentComment = "aweosome", OwnerComment = "you", PageId = 10};
            MessageRabbitClass msg3 = new MessageRabbitClass
            {
                MethodName = "CreateComment",
                Data = comment
            };
            var response3 = rpcClient.Call(msg3, "rec_con");
            Console.WriteLine(" [.] Got '{0}'", response3);

            #endregion

            #region Section

            ////// Section //////
            Thread.Sleep(5000);
            SectionDto section = new SectionDto
            {
                NameSection = "ITSGOOD",
                DecriptionSection = "god",
                OwnerSection = "weare"
            };
            MessageRabbitClass msg4 = new MessageRabbitClass
            {
                MethodName = "CreateSection",
                Data = section
            };
            var response4 = rpcClient.Call(msg4, "rec_con");
            Console.WriteLine(" [.] Got '{0}'", response4);

            #endregion

            Console.ReadLine();
            rpcClient.Close();
        }
    }
}
