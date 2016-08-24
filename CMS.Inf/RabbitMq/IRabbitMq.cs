using RabbitMQ.Client;

namespace CMS.Inf.RabbitMq
{
    interface IRabbitMq
    {

        IModel Connect(string host);
        void Send(string exchangeName, string routingKey, string message);

    }
}
