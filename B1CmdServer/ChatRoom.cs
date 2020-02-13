using Grpc.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B1CmdServer
{   
    public class ChatRoom
    {
        private ConcurrentDictionary<string, IServerStreamWriter<CommandMessage>> users = new ConcurrentDictionary<string, IServerStreamWriter<CommandMessage>>();

        public void Join(string userName, IServerStreamWriter<CommandMessage> response) => users.TryAdd(userName, response);

        public void Remove(string name) => users.TryRemove(name, out var s);

        public async Task BroadcastMessageAsync(CommandMessage commandMessage) => await BroadcastMessages(commandMessage);

        private async Task BroadcastMessages(CommandMessage commandMessage)
        {
            foreach (var user in users.Where(x => x.Key != commandMessage.UserName))
            {
                var item = await SendMessageToSubscriber(user, commandMessage);
                if (item != null)
                {
                    Remove(item?.Key);
                };
            }
        }

        private async Task<Nullable<KeyValuePair<string, IServerStreamWriter<CommandMessage>>>> SendMessageToSubscriber(KeyValuePair<string, IServerStreamWriter<CommandMessage>> user, CommandMessage message)
        {
            try
            {
                await user.Value.WriteAsync(message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return user;
            }
        }
    }
}
