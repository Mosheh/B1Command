using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace B1CmdServer
{
    public class ChatService: ChatB1.ChatB1Base
    {
        private readonly ILogger<ChatService> _logger;
        private readonly ChatRoom _chatRoom;
        public ChatService(ChatRoom chatRoom, ILogger<ChatService> logger)
        {
            _logger = logger;
            _chatRoom = chatRoom;
        }

        public override async Task join(IAsyncStreamReader<CommandMessage> requestStream, IServerStreamWriter<CommandMessage> responseStream, ServerCallContext context)
        {
            if (!await requestStream.MoveNext()) return;

            do
            {
                _chatRoom.Join(requestStream.Current.UserName, responseStream);
                await _chatRoom.BroadcastMessageAsync(requestStream.Current);
            } while (await requestStream.MoveNext());


        }
    }
}
