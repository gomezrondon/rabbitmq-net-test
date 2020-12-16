using System.Text;
using System.Threading;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RrabbitMQ.Producer
{
    public static class QueueProducer
    {
        public static void Publisher(IModel channel)
        {
            //declare a queue
            channel.QueueDeclare("demo-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var count = 0;

            while (true)
            {
                var message = new {Name = "Producer", Message = $"Hello! Count: {count}"};
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("", "demo-queue", null, body);
                count++;
                Thread.Sleep(1000);
            }

        }
    }
}