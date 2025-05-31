using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Temp.Listener
{
    public class Listener
    {
        public static void StartListening()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            var connection = factory.CreateConnection();
            
            using IModel channel =  connection.CreateModel();


            channel.QueueDeclare(queue: "eventQueue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Gets {message}");
            };

            channel.BasicConsume(queue: "eventQueue",
                autoAck: true,
                consumer: consumer);
            Console.WriteLine("Waiting......");
            Console.ReadLine();

            return;

        }
    }
}
