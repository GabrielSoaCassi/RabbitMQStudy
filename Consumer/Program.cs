using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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

/* 
 * var conexao = servidor.CreateConnection();
 * IModel channel = conexao.CreateModel();
 * channel.Close();
 * conexao.Close(); 
 */
//Canal usamos o using para não ter a necessidade de chamar o metodo close
using (var canal = conexao.CreateModel())
{
    //escutar fila
    canal.QueueDeclare(
        queue: "",
        durable: false, 
        exclusive: false, 
        autoDelete: false, 
        arguments: null);

    //Consumidor
    var consumidor = new EventingBasicConsumer(canal);
    //evento que o consumidor está escutando 
    consumidor.Received += (model, ea) =>
    {
        //vamos receber o corpo do rabbit
        var corpo = ea.Body.ToArray();
        //pegar a mensagem que está em bytes e converter
        var mensagem = Encoding.UTF8.GetString(corpo);
        //mostrando a mensagem
        Console.WriteLine(" [x] Recebido {0}", mensagem);
    };
    canal.BasicConsume(queue:"",autoAck:true,consumer:consumidor);

}
Console.WriteLine("Pressione [enter] para sair.");
Console.ReadKey();