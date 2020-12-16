using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RrabbitMQ.Producer
{
    public class QueueProducer
    {
        public static void Publisher(IModel channel)
        {
            //declare a queue
            channel.QueueDeclare("demo-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            var message = new {Name = "Producer", Message = "Hello!"};
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            
            channel.BasicPublish("","demo-queue",null, body);
        }
    }
}