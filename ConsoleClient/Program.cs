using B1CmdServer;
using Grpc.Net.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("SAP Business One commander");
            Console.WriteLine("Type a command to SAP B1");

            var command = Console.ReadLine();
            var user = new CommandMessage() { UserName = "MJM", Command = command };
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new ChatB1.ChatB1Client(channel);

            using (var chat = client.join())
            {
                _ = Task.Run(async () => {
                    while (await chat.ResponseStream.MoveNext(cancellationToken: CancellationToken.None))
                    {
                        var response = chat.ResponseStream.Current;
                        Console.WriteLine($"{response.UserId}-{response.UserName}: {response.Command }");
                    }
                });

                await chat.RequestStream.WriteAsync(new CommandMessage { UserName = user.UserName, UserId = user.UserId });

                string line;

                while ((line = Console.ReadLine()) != null)
                {
                    SendMessage(chat, new CommandMessage { UserName = user.UserName,  Command = line });

                }

                await chat.RequestStream.CompleteAsync();

                await channel.ShutdownAsync();
            }

            async static void SendMessage(Grpc.Core.AsyncDuplexStreamingCall<CommandMessage, CommandMessage> chat, CommandMessage user)
            {
                await chat.RequestStream.WriteAsync(user);
            }
            Console.ReadKey();
        }
    }
}
