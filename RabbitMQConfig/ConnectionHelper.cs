using RabbitMQ.Client;

public static class ConnectionHelper
{
    public static IConnection GetRabbitMqConnection()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            Port = 5672,
            UserName = "usuario",
            Password = "Senha@123"
        };

        return factory.CreateConnection();
    }
}
