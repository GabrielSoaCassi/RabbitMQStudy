using RabbitMQ.Client;
using System.Text;

//Servidor do Rabbitmq
var servidor = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 0,
    UserName = "",
    Password = ""
};

//Conexão com o servidor
var conexao = servidor.CreateConnection();
//Canal
using (var canal = conexao.CreateModel())
{
    //Criar fila ou escutar fila

    canal.QueueDeclare(
        queue: "",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null);

    //Mensagem
    string mensagem = "Hello World";
    //Converter mensagem para bytes
    var corpoMensagem = Encoding.UTF8.GetBytes(mensagem);
    canal.BasicPublish(
        exchange: "",
        routingKey: "",
        basicProperties: null,
        body: corpoMensagem);
    Console.WriteLine(" [x] Enviou {0}", mensagem);
}
Console.WriteLine("Pressione [enter] para sair.");
Console.ReadKey();