using System.Text;
using RabbitMQ.Client;

namespace Temp.Publisher
{
    public class Publisher
    {
        public static void SendMessage(string? message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();


            channel.QueueDeclare(queue: "eventQueue",
                durable: false,
                autoDelete:false,
                arguments:null,
                exclusive:false
                );
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                routingKey: "eventQueue",
                basicProperties: null,
                body: body);

            Console.WriteLine($"[x] Sent: {message}");
        }
    }
}
