using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConfig
{
    public class Consume
    {
        public static void ConsumeMessages(string queueName,string chatNameReceiving)
        {
            using var connection = ConnectionHelper.GetRabbitMqConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };
            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
            Console.WriteLine($"{chatNameReceiving}: Listening for messages. Press [enter] to exit.");
            while (true) { Task.Delay(100).Wait(); }
        }
    }
}
