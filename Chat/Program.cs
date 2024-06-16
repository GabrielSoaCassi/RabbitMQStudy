using RabbitMQConfig;

class Program
{
    static async Task Main(string[] args)
    {
        string chatName, myName;
        while (true)
        {
            Console.WriteLine("Advise if the chat not exist you can never receive messagem from it.");

            Console.WriteLine("Enter with a name you want use ... your partner need to know the name you use to connect with you");
            myName = Console.ReadLine();
            if (string.IsNullOrEmpty(myName))
            {
                Console.WriteLine("Invalid name.");
                Console.Clear();
                continue;
            }
            Console.WriteLine("Write the chat name you want to send message without blankSPace ex: \n ");
            chatName = Console.ReadLine();
            if (string.IsNullOrEmpty(chatName))
            {
                Console.WriteLine("Invalid Chat name.");
                Console.Clear();
                continue;
            }
            if (!string.IsNullOrEmpty(myName) && !string.IsNullOrEmpty(chatName)) break;
        }
        var sendTask = Task.Run(() => Send.SendMessages(chatName, myName));
        var consumeTask = Task.Run(() => Consume.ConsumeMessages(myName, chatName));
        await Task.WhenAll(sendTask, consumeTask);
    }
}