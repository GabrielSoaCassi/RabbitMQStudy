using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//RabbitMQServer
var server = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672,
    UserName = "usuario",
    Password = "Senha@123"
};

//Connect to server
var conn = server.CreateConnection();
using (var channel = conn.CreateModel())
{
    //selecting or creating a queue
    channel.QueueDeclare(
        queue: "queue_hello_world",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null);

    //Consumer
    var consumer = new EventingBasicConsumer(channel);

    //event for consumer
    consumer.Received += (model, ea) =>
    {
        //receiving rabbit mq body
        var bodyMessage = ea.Body.ToArray();
        //gotr a message
        var message = Encoding.UTF8.GetString(bodyMessage);
        //show message
        Console.WriteLine(" [x] Received {0}", message);
    };
    channel.BasicConsume(queue: "queue_hello_world", autoAck: true, consumer: consumer);

}
Console.WriteLine("Press [enter] to exit.");
Console.ReadKey();
