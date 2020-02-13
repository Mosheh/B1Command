using B1CmdClient.Data;
using B1CmdServer;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace B1CmdClient
{
    public class ClientChat
    {
        public static async Task Init()
        {
            var user = new CommandMessage();
            user.UserId = SAPConnection.Application.AppId;
            user.UserName = SAPConnection.Company.UserName;
            user.System = true;

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ChatB1.ChatB1Client(channel);

            using (var chat = client.join())
            {
                _ = Task.Run(async () =>
                {
                    while (await chat.ResponseStream.MoveNext(cancellationToken: CancellationToken.None))
                    {
                        var response = chat.ResponseStream.Current;
                        Console.WriteLine($"{response.UserId}-{response.UserName}: {response.Command }");
                    }
                });

                await chat.RequestStream.WriteAsync(new CommandMessage { UserName = user.UserName, UserId = user.UserId });

                string line;

                while ((line = Console.ReadLine())!=null)
                {
                    await chat.RequestStream.WriteAsync(new CommandMessage { UserName = user.UserName, UserId = user.UserId });
                }

                await chat.RequestStream.CompleteAsync();

                channel.ShutdownAsync();
            }
        }
    }
}
