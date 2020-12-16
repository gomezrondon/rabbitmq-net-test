using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RrabbitMQ.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
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