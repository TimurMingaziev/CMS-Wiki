using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Model;
using RabbitMQ.Client;


namespace CMS.Inf
{
    interface IRabbitMq
    {

        IModel Connect(string host, IModel channel);
        void Send(string exchangeName, string routingKey, string message);

    }
}
