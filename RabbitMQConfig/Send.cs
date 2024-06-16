using RabbitMQ.Client;
using System.Text;

namespace RabbitMQConfig
{
    public class Send
    {
        public static void SendMessages(string queueNameTarget,string chatNameSending)
        {
            using var connection = ConnectionHelper.GetRabbitMqConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueNameTarget, durable: false, exclusive: false, autoDelete: false, arguments: null);

            Console.WriteLine($"{chatNameSending}: Enter your message (type 'exit' to quit):");

            while (true)
            {
                string message = Console.ReadLine();
                if (message.ToLower() == "exit")
                    break;

                var body = Encoding.UTF8.GetBytes($"{chatNameSending}: " + message);

                channel.BasicPublish(
                    exchange: string.Empty,
                    routingKey: queueNameTarget,
                    basicProperties: null,
                    body: body);
            }
        }

    }
}
