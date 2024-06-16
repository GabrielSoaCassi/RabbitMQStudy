using RabbitMQ.Client;
using System.Text;

//RabbitMQ Server
var server = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672,
    UserName = "usuario",
    Password = "Senha@123"
};

//Server conn
using var conn = server.CreateConnection();
//Channel
using var chanel = conn.CreateModel();
//Create Queue
chanel.QueueDeclare(
    queue: "queue_hello_world",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);

//Message
string message = "Hello World";
//Convert to bytes[]
var bodyMessage = Encoding.UTF8.GetBytes(message);
chanel.BasicPublish(
    exchange: "",
    routingKey: "queue_hello_world",
    basicProperties: null,
    body: bodyMessage);
Console.WriteLine(" [x] Send {0}", message);

Console.WriteLine("Press [enter] to exit.");
Console.ReadKey();

